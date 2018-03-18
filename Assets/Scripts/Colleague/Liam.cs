using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liam : MonoBehaviour {

	public Animator animator;
	public Vector3 startPosition;
	public Vector3 startRotationEuler;
	public Vector3 endPosition;
	public Vector3 currentPosition;

	[Header("Sounds")]
	[SerializeField] private AudioSource liamAudioSource;
	[SerializeField] private AudioClip pain;
	[SerializeField] private AudioClip fall;

	private Quaternion startRotation;
	[SerializeField] private float movingBiaisis;

	void Awake(){
		Debug.Log ("start");
		currentPosition = startPosition;
		this.transform.position = startPosition;
		startRotation = Quaternion.Euler (startRotationEuler);
		this.transform.rotation = startRotation;
		liamAudioSource = this.gameObject.GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetKeyDown ("1")) {
			StartCoroutine ("Walking");
		}
	}

	public void StartCardiacArrest(){
		StartCoroutine ("Walking");
	}

	IEnumerator Walking(){
		animator.SetBool ("StartWalking", true);
		while (Vector3.Distance(currentPosition, endPosition) > 0.1f) {
			currentPosition += transform.forward * movingBiaisis;
			this.transform.position = currentPosition;
			yield return 0;
		}
		animator.SetBool ("StartDying", true);
	}

	public void Die(){
		StartCoroutine ("Dying");
	}

	IEnumerator Dying(){
		liamAudioSource.clip = pain;
		liamAudioSource.Play ();

		yield return new WaitForSeconds (2f);
		liamAudioSource.clip = fall;
		liamAudioSource.Play ();

		yield return new WaitForSeconds (3f);
		Scenario.NextStep ();
	}

}
