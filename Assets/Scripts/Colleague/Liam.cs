using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liam : MonoBehaviour {

	public Animator animator;
	public Vector3 startPosition;
	public Vector3 startRotationEuler;
	public Vector3 endPosition;
	public Vector3 currentPosition;

	private Quaternion startRotation;

	void Awake(){
		Debug.Log ("start");
		currentPosition = startPosition;
		this.transform.position = startPosition;
		startRotation = Quaternion.Euler (startRotationEuler);
		this.transform.rotation = startRotation;
	}

	void Update(){
		if (Input.GetKeyDown ("1")) {
			Debug.Log ("startwalking");
//			StartCoroutine ("Walking");
		} else {
			Debug.Log ("not walking");
		}
	}

	IEnumerator Walking(){
		animator.SetBool ("StartWalking", true);
		while (Vector3.Distance(currentPosition, endPosition) > 0.1f) {
			Vector3 currentPosition = (endPosition - startPosition) * Time.deltaTime;
			this.transform.position = currentPosition;
			yield return 0;
		}
		animator.SetBool ("StartDying", true);
	}

}
