using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step02 : BasicStep
{

    public override void Enter(){
		Liam.instance.StartCardiacArrest();        
    }

    public override void Exit(){}

}
