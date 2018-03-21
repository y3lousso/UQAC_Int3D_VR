using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step11 : BasicStep
{
    [Header("Step11 spec")]

	[SerializeField] private Transform LiamsHead;
	[SerializeField] private float endRotationX;
	[SerializeField] private float rotationStep;

    public override void Enter()
    {
        StartCoroutine("HeadTilt");
	}

    public override void Exit()
    {

    }

    IEnumerator HeadTilt()
    {
        while (LiamsHead.rotation.x > endRotationX)
        {
            LiamsHead.rotation = Quaternion.Euler(new Vector3(LiamsHead.rotation.x, LiamsHead.rotation.y - rotationStep, LiamsHead.rotation.z));
            yield return 0;
        }

        Debug.Log("step11 complete");
        this.Complete();
    }
}
