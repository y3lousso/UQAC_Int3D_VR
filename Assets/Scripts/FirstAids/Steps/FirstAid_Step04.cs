using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step04 : BasicStep
{
    void Update(){
		if (UserController.instance.currentState == UserState.kneeling && LiamInteraction.instance.isCloseEnough)
        {
			this.Complete();
		}
	}

	public override void Enter(){}
	public override void Exit(){}
}
