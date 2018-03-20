using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step23 : BasicStep
{
	[Header("Sounds")]
	[SerializeField] private AudioSource source;
	[SerializeField] private AudioClip shock;

    public override void Enter(){
		StartStep23 ();
	}

    public override void Exit(){}

	void StartStep23(){
		StartCoroutine ("Step23");
	}

	IEnumerator Step23(){
		source.clip = shock;
		source.Play ();
		yield return new WaitForSeconds (shock.length);

		Debug.Log ("Step23 complete");
		this.Complete ();
	}
}
