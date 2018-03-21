using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step09 : BasicStep
{

    public override void Enter(){}
    public override void Exit(){}

    public void Update()
    {
        if (this.IsActivated && LiamInteraction.instance.isTieRemoved == true)
        {
            this.Complete();
        }
    }
}
