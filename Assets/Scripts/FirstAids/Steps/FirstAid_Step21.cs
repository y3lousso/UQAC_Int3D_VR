using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step21 : BasicStep
{
    public override void Enter(){}
    public override void Exit(){}


    private void Update()
    {
        if (this.IsActivated && UserController.instance.holdElectrodes)
        {
            this.Complete();
        }
    }

}
