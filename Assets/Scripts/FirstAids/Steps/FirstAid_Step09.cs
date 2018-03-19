using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step09 : BasicStep
{
	[SerializeField] private GameObject tie;

    public override void Enter(){}
    public override void Exit(){}

	public void RemoveTie(){
		tie.gameObject.SetActive (false);

		Debug.Log ("step09 complete");
		this.Complete ();
	}
}
