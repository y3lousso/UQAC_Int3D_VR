using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step20 : BasicStep
{
    public override void Enter(){}
    public override void Exit(){}

	public void StripVictimsChest(){
		//modify material of Liam so that the chest skin is visible

		Debug.Log ("step20 complete");
		this.Complete ();
	}
}
