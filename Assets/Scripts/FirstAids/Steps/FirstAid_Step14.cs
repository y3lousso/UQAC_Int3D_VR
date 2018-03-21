using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step14 : BasicStep
{
    private void Update()
    {
        if (LiamInteraction.instance.isListenningBreathing)
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
