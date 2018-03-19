using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step05 : BasicStep
{
    public LiamInteraction liamInteraction;

    void Update()
    {
        if (liamInteraction.leftHand.isTouching | liamInteraction.rightHand.isTouching)
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
