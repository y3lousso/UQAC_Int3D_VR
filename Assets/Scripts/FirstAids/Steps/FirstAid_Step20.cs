using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step20 : BasicStep
{
    public GameObject shirtTrigger;

    public void Start()
    {
        shirtTrigger.SetActive(false);
    }

    void Update(){
		if(this.IsActivated && LiamInteraction.instance.isShirtRemoved)
        {
			this.Complete ();
		}
	}

    // Start after the activation of the step
    public override void Enter()
    {
        shirtTrigger.SetActive(true);
    }

    // Start before the completion of the step
    public override void Exit()
    {
        shirtTrigger.SetActive(false);
    }
}
