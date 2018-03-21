using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirstAid_Step06 : BasicStep
{
   void Update()
    {
        if ( (this.IsActivated && LiamInteraction.instance.leftHand.isHolding | LiamInteraction.instance.rightHand.isHolding) && AudioTrigger.instance.isTalking)
        {
            StopCoroutine(AudioTrigger.instance.DetectAudio());
            this.Complete();
        }
    }
    // Start after the activation of the step
    public override void Enter()
    {
        StartCoroutine(AudioTrigger.instance.DetectAudio());
   }

    // Start before the completion of the step
    public override void Exit()
    {

    }
}
