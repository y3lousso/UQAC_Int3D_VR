using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step04 : BasicStep
{
	[SerializeField] private UserController user;
	[SerializeField] private bool isInCorrectArea;

	void Start(){
		isInCorrectArea = false;
	}

	void Update(){
		if (user.currentState == UserState.kneeling && isInCorrectArea) {
			this.Complete();
			Debug.Log ("complete !");
		}
	}

	void OnTriggerEnter(){
		isInCorrectArea = true;
	}

	void OnTriggerExit(){
		isInCorrectArea = false;
	}

	public override void Enter(){}
	public override void Exit(){}
}
