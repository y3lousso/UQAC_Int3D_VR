using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step20 : BasicStep
{

    public override void Enter(){}
    public override void Exit(){}


	void Update(){
		if(this.IsActivated && LiamInteraction.instance.isShirtRemoved)
        {
			this.Complete ();
		}
	}
}
