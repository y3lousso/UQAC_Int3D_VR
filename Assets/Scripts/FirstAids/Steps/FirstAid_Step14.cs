using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step14 : BasicStep
{
    private void Update()
    {
        if (LiamInteraction.instance.isListenningBreathing)
        {
			StartCoroutine ("CheckECG");
        }
    }

	public IEnumerator CheckECG(){
		//launch ECG
		yield return new WaitForSeconds(10);
		this.Complete ();
	}

    public override void Enter(){}
    public override void Exit(){}
}
