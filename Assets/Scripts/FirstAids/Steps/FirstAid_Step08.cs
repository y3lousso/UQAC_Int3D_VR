using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step08 : BasicStep
{

    public override void Enter(){
		StartCoroutine ("CompleteAfterAudio");
    }

    public override void Exit(){}

	IEnumerator CompleteAfterAudio(){
		yield return new WaitForSeconds (8f);
		this.Complete ();
	}
}
