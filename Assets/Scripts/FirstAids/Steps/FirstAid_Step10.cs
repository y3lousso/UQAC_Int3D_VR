using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step10 : BasicStep
{
    public override void Enter(){}
    public override void Exit(){}

	void Update(){
		if (this.IsActivated && LiamInteraction.instance.chin.isHolding && LiamInteraction.instance.forehead.isHolding)
        {
			this.Complete ();
		}
	}
}
