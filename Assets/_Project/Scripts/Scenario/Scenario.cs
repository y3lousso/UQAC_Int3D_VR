using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour {

    public AudioManager AudioManager { get; private set; }

    [Header("Scenario Management")]
    public BasicStep rootStep;
    public List<BasicStep> activatedSteps = new List<BasicStep>();
    public List<BasicStep> completedSteps = new List<BasicStep>();

    public void Awake()
    {
        AudioManager = GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start () {
        // Try to activate the root step : it should always Activate.
        rootStep.TryActivate();
    }
    
    /// <summary>
    /// Entry point for help button
    /// </summary>
	public void OnHelpButtonPressed()
    {       
        AudioManager.PlaySoundClip(activatedSteps[0].audioHelpClip);
        if (activatedSteps[0].flickeringObject != null)
        {
            activatedSteps[0].flickeringObject.IsFlickering = true;
        }
    }

    #region Step Following

    public void AddActiveStep(BasicStep step)
    {
        activatedSteps.Add(step);
    }

    public void RemoveActiveStep(BasicStep step)
    {
        if(step == activatedSteps[0] && activatedSteps[0].flickeringObject != null)
        {
            activatedSteps[0].flickeringObject.IsFlickering = false;
        }
        activatedSteps.Remove(step);
    }

    public void AddCompletedStep(BasicStep step)
    {
        completedSteps.Add(step);
    }

    public void RemoveCompletedStep(BasicStep step)
    {
        completedSteps.Remove(step);
    }

    #endregion

    public void ForceComplete()
    {
        activatedSteps[0].Complete();
    }
}
