using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid_Step12 : BasicStep
{
    public GameObject mouthTrigger;

    public void Start()
    {
        mouthTrigger.SetActive(false);
    }

    void Update()
    {
        if (this.IsActivated && LiamInteraction.instance.mouth.isHolding)
        {
            this.Complete();
        }
    }

    // Start after the activation of the step
    public override void Enter()
    {
        mouthTrigger.SetActive(true);
    }

    // Start before the completion of the step
    public override void Exit()
    {
        mouthTrigger.SetActive(false);
    }
}
