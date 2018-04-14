using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step23 : BasicStep
{
	[Header("Sounds")]
	[SerializeField] private AudioSource source;
	[SerializeField] private AudioClip shock;

    public override void Enter(){
        StartCoroutine("Step23");
    }

    public override void Exit(){}

	IEnumerator Step23(){        
		source.clip = shock;
		source.Play ();
        VRControllerManager.instance.PlayHapticBothHand(.3f, shock.length, .05f);
        yield return new WaitForSeconds (shock.length);

		this.Complete ();
	}
}
