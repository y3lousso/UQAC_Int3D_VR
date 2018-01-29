﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>  
/// 	This class is used to animate GameObjects
///		The objects can be animated as loops or as single time animations
/// </summary>
/// <remarks>
/// 	Used by traps
/// </remarks>
public class AnimatePosition : MonoBehaviour {

    [Header("Animation settings")]
    public bool runOnStart = false;
    public bool running = false;
    public float refreshTime = 0.01f;
    public bool requestedStop = false;

    [Header("Movement settings")]
    public AnimationCurve posXCurve = AnimationCurve.Constant(0, 1, 0);
	public AnimationCurve posYCurve = AnimationCurve.Constant(0, 1, 0);
	public AnimationCurve posZCurve = AnimationCurve.Constant(0, 1, 0);

	public AnimationCurve rotXCurve = AnimationCurve.Constant(0, 1, 0);
	public AnimationCurve rotYCurve = AnimationCurve.Constant(0, 1, 0);
	public AnimationCurve rotZCurve = AnimationCurve.Constant(0, 1, 0);

	
	

	/// <summary>  
	///		Starts the animation if runOnStart is true
	/// </summary> 
	void Start() {
		if (runOnStart) {
			StartAnimation();
		}
	}

	/// <summary>  
	/// 	Run the animation if not already running
	/// </summary> 
	public void StartAnimation () {
		gameObject.SetActive(true);

		if (!running)
			StartCoroutine(RunAnimation());
	}

	/// <summary>  
	/// 	Stop the animation if it's running in a loop
	/// </summary> 
	public void StopAnimation () {
		requestedStop = true;
	}

	/// <summary>  
	/// 	Coroutine running the animation
	/// </summary> 
	IEnumerator RunAnimation () {
		Vector3 startPos = transform.localPosition;
		Vector3 startRot = transform.localRotation.eulerAngles;

		float startTime = Time.realtimeSinceStartup;
		running = true;

		while (!requestedStop) {
			float curTime = Time.realtimeSinceStartup - startTime;

			transform.localPosition = startPos + new Vector3(posXCurve.Evaluate(curTime), posYCurve.Evaluate(curTime), posZCurve.Evaluate(curTime));
			transform.localRotation = Quaternion.Euler(startRot + new Vector3(rotXCurve.Evaluate(curTime), rotYCurve.Evaluate(curTime), rotZCurve.Evaluate(curTime)));

			yield return new WaitForSeconds(refreshTime);
		}

		running = false;
		requestedStop = false;
		
		transform.localPosition = startPos;
		transform.localRotation = Quaternion.Euler(startRot);
	}
}
