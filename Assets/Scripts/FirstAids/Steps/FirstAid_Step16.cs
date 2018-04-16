using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FirstAid_Step16 : BasicStep
{
    void Update()
    {
        if (this.IsActivated && AudioTrigger.instance.isTalking)
        {
            StopCoroutine(AudioTrigger.instance.DetectAudio());
            Invoke("Complete", 2f);
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
