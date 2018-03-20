using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicStep : MonoBehaviour {

    protected Scenario scenario;

    [Header("Scenario Management")]
    public bool autoPassAfterAudioStart = false;
    public List<BasicStep> previousSteps;
    public List<BasicStep> nextSteps;

    private bool isActivated;
    public bool IsActivated
    {
        get
        {
            return isActivated;
        }
        set
        {
            if(value == true)
            {
                isActivated = true;
                scenario.AddActiveStep(this);
                Activate();
            }
            else
            {
                isActivated = false;
                scenario.RemoveActiveStep(this);
            }           
        }
    }
    private bool isCompleted;
    public bool IsCompleted
    {
        get
        {
            return isCompleted;
        }
        set
        {
            if (value == true)
            {
                isCompleted = true;
                scenario.AddCompletedStep(this);
            }
            else
            {
                isCompleted = false;
                scenario.RemoveCompletedStep(this);
            }
        }
    }

    [Header("Step Instructions")]
    public AudioClip audioStartClip;
    public AudioClip audioHelpClip;
    public FlickeringObject flickeringObject;

    private void Awake()
    {
        scenario = GetComponentInParent<Scenario>();


    }



    public abstract void Enter();
    public abstract void Exit();

    /// <summary>
    /// Start when the step start to be effective
    /// </summary>
    public void Activate()
    {
        scenario.AudioManager.PlaySoundClip(audioStartClip, true);
        if (autoPassAfterAudioStart)
        {
            StartCoroutine("AutoPassAfterClip", audioStartClip.length);
        }
        Enter();
    }

    /// <summary>
    /// Complete the step after playing the start audio clip.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator AutoPassAfterClip(float time)
    {
        yield return new WaitForSeconds(time);
        Complete();
    }

    /// <summary>
    /// Activate the step only if all previous steps are completed
    /// </summary>
    public void TryActivate()
    {
        // if all previous step are completed or no previous step
        bool previousStepsCompleted = true;       
        foreach (BasicStep previousStep in previousSteps) 
        {
            previousStepsCompleted &= previousStep.IsCompleted;
        }

        // If all the previous steps are completed
        if (previousStepsCompleted == true)
        {
            IsActivated = true;                       
        }
    }

    /// <summary>
    /// Every time a step is completed, it will try to activate the next steps
    /// Call this method from superclass when step is completed
    /// </summary>
    public void Complete()
    {
        Exit();
        if (IsActivated)
        {
            // Remove the step from activated step list
            IsActivated = false;
            // Add the step to completed step list
            IsCompleted = true;

            // Try to activate the following step
            foreach (BasicStep nextStep in nextSteps)
            {
                nextStep.TryActivate();
            }           
        }
    }
}
