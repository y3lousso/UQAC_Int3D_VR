using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step05 : BasicStep
{
    void Update()
    {
        if (LiamInteraction.instance.leftHand.isTouching | LiamInteraction.instance.rightHand.isTouching)
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
