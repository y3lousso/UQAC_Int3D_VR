using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step18 : BasicStep
{
	[Header("Specific Step18")]
	[SerializeField] private AudioSource source;
	[SerializeField] private AudioClip phone;

    public override void Enter(){}

    public override void Exit(){}

	public void StartPhone(){
		StartCoroutine ("PhoneActivation");
	}

	IEnumerator PhoneActivation(){
		Debug.Log ("Phone activation");

		source.clip = phone;
		source.Play ();
		yield return new WaitForSeconds (phone.length);

		this.Complete ();
	}
}
