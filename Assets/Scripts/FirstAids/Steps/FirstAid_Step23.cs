using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step23 : BasicStep
{
	[Header("Sounds")]
	[SerializeField] private AudioSource source;
	[SerializeField] private AudioClip instructions;
	[SerializeField] private AudioClip shock;

    public override void Enter(){
		StartStep23 ();
	}

    public override void Exit(){}

	void StartStep23(){
		StartCoroutine ("Step23");
	}

	IEnumerator Step23(){
		source.clip = instructions;
		source.Play ();
		yield return new WaitForSeconds (instructions.length);

		source.clip = shock;
		source.Play ();
		yield return new WaitForSeconds (shock.length);


	}
}
