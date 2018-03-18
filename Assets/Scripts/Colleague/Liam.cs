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

	void Awake(){
		liamAudioSource = this.gameObject.GetComponent<AudioSource> ();
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
	}

}
