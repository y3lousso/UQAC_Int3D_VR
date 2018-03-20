using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step21 : BasicStep
{
    public override void Enter(){}
    public override void Exit(){}

	public void TakeElectrodes(){
		if (this.IsActivated) {
			//TODO put electrodes on hand

			scenario.user.holdElectrodes = true;

			Debug.Log ("step21 complete");
			this.Complete ();
		} else {
			Debug.Log ("not in the right step");
		}
	}

}
