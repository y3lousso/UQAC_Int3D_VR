using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step19 : BasicStep
{

	[SerializeField] private GameObject AED;
	[SerializeField] private Collider correctArea;

	private bool AEDIsInArea;
	private bool AEDIsGrabbed;

    public override void Enter(){}
    public override void Exit(){}

	void Start(){
		AEDIsGrabbed = false;
	}

	void Update(){
		if (AEDIsInArea && !AEDIsGrabbed && !this.IsCompleted) {
			this.Complete ();
			Debug.Log ("Step19 complete");
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.name == AED.name)
			AEDIsInArea = true;
	}

	void OnTriggerExit(Collider col){
		if (col.name == AED.name)
			AEDIsInArea = false;
	}

	public void GrabAED(){
		AEDIsGrabbed = true;
	}

	public void UngrabAED(){
		AEDIsGrabbed = false;
	}
}
"