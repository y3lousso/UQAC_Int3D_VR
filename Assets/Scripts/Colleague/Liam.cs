using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liam : MonoBehaviour {

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

	[Header("Clothes")]
	[SerializeField] private GameObject tie;

	[Header("Body")]
	[SerializeField] private Transform head;
	[SerializeField] private GameObject electrode1;
	[SerializeField] private GameObject electrode2;

	void Awake(){
		liamAudioSource = this.gameObject.GetComponent<AudioSource> ();

		electrode1.SetActive (false);
		electrode2.SetActive (false);

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

	public void StartHeadTilt(){
		this.GetComponent<Animator> ().enabled = false;

		Debug.Log ("startrotation");
		head.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (180, 0, 0), Time.deltaTime * 10f);
//		StartCoroutine ("HeadTilt");
	}

//	IEnumerator HeadTilt(){
//		while (head.rotation.eulerAngles.x > -26f) {
//			head.rotation = Quaternion.Euler (new Vector3(head.rotation.x, head.rotation.y - 0.01f, head.rotation.z));
//			yield return 0;
//		}
//
//		Debug.Log ("head tilt complete");
//	}
}
