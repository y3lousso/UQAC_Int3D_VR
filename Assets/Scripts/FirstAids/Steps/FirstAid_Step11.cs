using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step11 : BasicStep
{
    public override void Enter()
    {
        Liam.instance.StartHeadTilt();
        this.Complete();
    }

    public override void Exit()
    {

    }
}
