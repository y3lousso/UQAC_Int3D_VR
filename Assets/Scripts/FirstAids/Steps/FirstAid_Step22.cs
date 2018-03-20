using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step22 : BasicStep
{
	[SerializeField] private GameObject electrode1;
	[SerializeField] private GameObject electrode2;

	private bool electrode1IsPositionned;
	private bool electrode2IsPositionned;

    public override void Enter(){}
    public override void Exit(){}

	void Update(){
		if (electrode1IsPositionned && electrode2IsPositionned && this.IsActivated && !this.IsCompleted) {
			Debug.Log ("Step22 complete");
			this.Complete ();
		}
	}

	public void PositionElectrodes(){
		if (scenario.user.holdElectrodes) {
			if (!electrode1IsPositionned) {
				PutElectrode1 ();
			} else {
				PutElectrode2 ();
			}
		} else {
			Debug.Log ("Take the electrodes first");
		}
	}

	void PutElectrode1(){
		Debug.Log ("Electrode 1 is positionned");
		electrode1.SetActive (true);
		electrode1IsPositionned = true;
	}

	void PutElectrode2(){
		Debug.Log ("Electrode 2 is positionned");
		electrode2.SetActive (true);
		electrode2IsPositionned = true;
	}
}
