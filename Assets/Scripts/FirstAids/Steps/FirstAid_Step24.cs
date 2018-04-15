using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step24 : BasicStep
{

    private void Update()
    {
        if (LiamInteraction.instance.isListenningBreathing)
        {
			scenario.ecgmanager.StartHeartBeat (this);
        }
    }

    public override void Enter(){}
    public override void Exit(){}
}
