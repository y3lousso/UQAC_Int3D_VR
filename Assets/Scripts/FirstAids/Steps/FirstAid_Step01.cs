using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step01 : BasicStep
{
    public Door door;

    private void Update()
    {
        if (door.isOpen)
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
