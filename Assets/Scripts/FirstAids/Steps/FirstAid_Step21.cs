using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step21 : BasicStep
{

	[SerializeField] private UserController user;

    public override void Enter(){}
    public override void Exit(){}

	public void TakeElectrodes(){
		if (this.IsActivated) {
			//TODO put electrodes on hand

			user.holdElectrodes = true;

			Debug.Log ("step21 complete");
			this.Complete ();
		} else {
			Debug.Log ("not in the right step");
		}
	}

}
