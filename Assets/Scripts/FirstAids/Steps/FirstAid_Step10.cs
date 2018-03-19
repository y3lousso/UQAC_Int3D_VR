using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step10 : BasicStep
{

	[SerializeField] private LiamBodyPart chin;
	[SerializeField] private LiamBodyPart forehead;

    public override void Enter(){}
    public override void Exit(){}

	void Update(){
		if (chin.isTouching && forehead.isTouching && !this.IsCompleted) {
			//TODO head animation

			Debug.Log ("step10 complete");
			this.Complete ();
		}
	}
}
