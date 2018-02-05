using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStep : MonoBehaviour {

    
    private Scenario scenario;
   
    [Header("Scenario Management")]
    public bool isAnimationStep = false;
    public List<BasicStep> previousSteps;
    public List<BasicStep> nextSteps;
    public bool isActivated = false;
    public bool isCompleted = false;

    [Header("Step Instructions")]
    public AudioClip audioStartClip;
    public AudioClip audioHelpClip;
    public FlickeringObject flickeringObject;


    public void Awake()
    {
        scenario = GetComponentInParent<Scenario>();
    }

    /// <summary>
    /// When the step start to be effective
    /// </summary>
    public void Activate()
    {
        if (isAnimationStep)
        {
            StartCoroutine("AutoPassAfterClip", audioStartClip.length);
        }
        scenario.PlaySoundClip(audioStartClip, true);

    }

    public IEnumerator AutoPassAfterClip(float time)
    {
        yield return new WaitForSeconds(time);
        Complete();
    }

    public void SetFlickerAssociatedObject(bool state)
    {
        if (flickeringObject != null)
        {
            flickeringObject.SetFlickering(state);
        }
        else
        {
            Debug.Log(gameObject.name + "need a flickering object scrip.");
        }
    }

    #region StepOrganization
    /// <summary>
    /// Activate the step only if all previous steps are completed
    /// </summary>
    public void TryActivate()
    {
        bool previousStepsCompleted = true;
        foreach (BasicStep previousStep in previousSteps) // if all previous step are completed or no previous step
        {
            previousStepsCompleted &= previousStep.isCompleted;
        }
        // If all the previous steps are completed
        if (previousStepsCompleted == true)
        {
            isActivated = true;
            scenario.AddActiveStep(this);
            Activate();
        }
    }

    /// <summary>
    /// Every time a step is completed, it will try to activate the next steps
    /// Call this method from superclass when step is completed
    /// </summary>
    public void Complete()
    {
        if (isActivated)
        {
            isActivated = false;
            scenario.RemoveActiveStep(this);

            isCompleted = true;
            scenario.AddCompletedStep(this);

            foreach (BasicStep nextStep in nextSteps)
            {
                nextStep.TryActivate();
            }
            
        }
    }
    #endregion
}
