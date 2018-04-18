using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step10 : BasicStep
{
    public GameObject chinTrigger;
    public GameObject foreheadTrigger;

    public void Start()
    {
        chinTrigger.SetActive(false);
        foreheadTrigger.SetActive(false);
    }

    void Update(){
		if (this.IsActivated && LiamInteraction.instance.chin.isHolding && LiamInteraction.instance.forehead.isHolding)
        {
			this.Complete ();
		}
	}
    public override void Enter()
    {
        chinTrigger.SetActive(true);
        foreheadTrigger.SetActive(true);
    }

    public override void Exit()
    {
        chinTrigger.SetActive(false);
        foreheadTrigger.SetActive(false);
    }

}
