using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step20 : BasicStep
{

    public SkinnedMeshRenderer top;
    public GameObject chestCollider;

    public override void Enter(){}
    public override void Exit(){}


	public void StripVictimsChest(){
		if(this.IsActivated){
            //modify material of Liam so that the chest skin is visible
            top.sharedMaterial.color = new Color(97f/255,26f/255,9f/255);
            chestCollider.SetActive(false);

            Debug.Log ("step20 complete");
			this.Complete ();
		}
	}
}
