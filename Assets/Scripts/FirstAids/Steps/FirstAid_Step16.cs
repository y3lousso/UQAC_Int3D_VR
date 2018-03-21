using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirstAid_Step16 : BasicStep
{
    Thread audio_detect_th;
    void Update()
    {
        if (AudioTrigger.instance.isTalking)
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
