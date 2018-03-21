using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step05 : BasicStep
{
    void Update()
    {
        if (this.IsActivated && LiamInteraction.instance.leftHand.isHolding | LiamInteraction.instance.rightHand.isHolding)
        {
            this.Complete();
        }
    }

    // Start after the activation of the step
    public override void Enter()
    {

    }

    // Start before the completion of the step
    public override void Exit()
    {

    }
}
