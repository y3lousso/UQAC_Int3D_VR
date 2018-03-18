using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {

	public enum UserState {standing, kneeling};

	[Header ("Start")]
	[SerializeField] private Vector3 startPosition;
	[SerializeField] private Vector3 startEulerRot;

	[Header("State")]
	public UserState currentState;
	[SerializeField] private bool changingState;

	[Header ("Body")]
	[SerializeField] private GameObject Setups;

	private Quaternion startRotation;

	void Start () {
		transform.position = startPosition;
		startRotation = Quaternion.Euler (startEulerRot);
		transform.rotation = startRotation;

		currentState = UserState.standing;
		changingState = false;
	}
	
	void Update () {
		if (Input.GetKeyDown ("c") && !changingState) {
			ToggleHeightPosition ();
		}
	}

	void ToggleHeightPosition(){
		if (currentState == UserState.kneeling)
			StartCoroutine ("Stand");
		else if (currentState == UserState.standing)
			StartCoroutine ("Kneel");
	}

	IEnumerator Kneel(){
		changingState = true;
		float finalHeight = -0.6f;

		while (Setups.transform.position.y > finalHeight) {
			Setups.transform.position += new Vector3(0, -0.01f, 0);
			yield return 0;
		}

		currentState = UserState.kneeling;
		changingState = false;
	}

	IEnumerator Stand(){
		changingState = true;
		float finalHeight = 0f;

		while (Setups.transform.position.y < finalHeight) {
			Setups.transform.position += new Vector3(0, 0.01f, 0);
			yield return 0;
		}

		currentState = UserState.standing;
		changingState = false;
	}
}
