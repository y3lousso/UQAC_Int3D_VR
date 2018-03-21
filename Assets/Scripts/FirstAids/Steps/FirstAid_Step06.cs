using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirstAid_Step06 : BasicStep
{
    Thread audio_detect_th;
    void Update()
    {
        if ( (LiamInteraction.instance.leftHand.isTouching | LiamInteraction.instance.rightHand.isTouching ) && AudioTrigger.instance.isTalking)
        {
            audio_detect_th.Abort();
            this.Complete();
        }
    }
    // Start after the activation of the step
    public override void Enter()
    {
        audio_detect_th = new Thread(new ThreadStart(AudioTrigger.instance.DetectAudio));
        audio_detect_th.Start();
    }

    // Start before the completion of the step
    public override void Exit()
    {

    }
}
