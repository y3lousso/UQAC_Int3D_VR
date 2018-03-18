using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step02 : BasicStep
{

	[SerializeField] Liam liam;

    // Start after the activation of the step
    public override void Enter()
    {
        liam.StartCardiacArrest();
    }

    // Start before the completion of the step
    public override void Exit()
    {

    }

}
