using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step06 : BasicStep
{

    void Update()
    {
        if ( (LiamInteraction.instance.leftHand.isTouching | LiamInteraction.instance.rightHand.isTouching ) && AudioTrigger.instance.isTalking)
        {
            this.Complete();
        }
    }
    // Start after the activation of the step
    public override void Enter()
    {
        // Hopefully this won't block everything...
        do
        {
            AudioTrigger.instance.DetectAudio();
        } while (!AudioTrigger.instance.isTalking);
    }

    // Start before the completion of the step
    public override void Exit()
    {

    }
}
