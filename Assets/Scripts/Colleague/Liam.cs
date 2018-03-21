using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liam : MonoBehaviour {

    public static Liam instance;

    public Animator animator;

    [Header("Deplacement")]
    public Transform start;
    public Transform end;
    [Range(0.1f, 20f)]
    public float deplacementTime = 5f;

    [Header("Sounds")]
	[SerializeField] private AudioSource liamAudioSource;
	[SerializeField] private AudioClip pain;
	[SerializeField] private AudioClip fall;

	[Header("Body")]
	[SerializeField] private Transform head;

    [Header("Head Tilt")]
    [SerializeField] private Vector3 endRotation = new Vector3(210, -180, 180);
    [SerializeField] private float rotationTime = 2f;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("Singleton error");
        }
    }

    void Start()
    {
		liamAudioSource = this.gameObject.GetComponent<AudioSource> ();
    }

	void Update(){
		if (Input.GetKeyDown ("1"))
			StartHeadTilt ();
	}

    public void StartCardiacArrest(){
        StartCoroutine("Walking");
	}

	IEnumerator Walking(){
		animator.SetBool ("StartWalking", true);
        float currentTime = 0;
        while (currentTime<=deplacementTime)
        {
            transform.position = Vector3.Lerp(start.position, end.position, currentTime / deplacementTime);
            transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, currentTime / deplacementTime);
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
        }
        Die();
	}

	public void Die(){
        animator.SetBool("StartDying", true);
        StartCoroutine ("Dying");
	}

	IEnumerator Dying(){
		liamAudioSource.clip = pain;
		liamAudioSource.Play ();
		yield return new WaitForSeconds (2f);

		liamAudioSource.clip = fall;
		liamAudioSource.Play ();

		yield return new WaitForSeconds (3f);
        Scenario.Instance.GetStep(2).Complete();
		animator.enabled = false;
	}

	public void StartHeadTilt()
    {
		this.GetComponent<Animator> ().enabled = false;
 		StartCoroutine ("HeadTilt");
	}

    IEnumerator HeadTilt()
    {
        Vector3 startRotation = head.rotation.eulerAngles;
        float currentTime = 0f;
        Debug.Log(currentTime);

        while (currentTime < rotationTime)
        {
            currentTime += rotationTime;
            head.localRotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, currentTime / rotationTime));
            yield return new WaitForSeconds(.01f);
        }
    }
}
