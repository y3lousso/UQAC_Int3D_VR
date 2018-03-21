using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step22 : BasicStep
{
    public override void Enter(){}
    public override void Exit(){}

	void Update(){
		if (this.IsActivated && LiamInteraction.instance.isElectrodeLeftPlaced && LiamInteraction.instance.isElectrodeRightPlaced)
        {
			this.Complete ();
		}
	}
}
