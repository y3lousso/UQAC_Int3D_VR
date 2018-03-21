using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_EndStep : BasicStep
{

    // Start after the activation of the step
    public override void Enter()
    {
        SceneManager.instance.ChangeScene("Home");
    }

    // Start before the completion of the step
    public override void Exit()
    {

    }
}
