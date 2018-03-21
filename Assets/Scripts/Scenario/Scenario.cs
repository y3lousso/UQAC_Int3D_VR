using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour {

    public AudioManager AudioManager { get; private set; }

    [Header("Scenario Management")]
    public BasicStep rootStep;
    public List<BasicStep> activatedSteps = new List<BasicStep>();
    public List<BasicStep> completedSteps = new List<BasicStep>();

	public static Scenario Instance;

    void Awake()
    {
        AudioManager = GetComponent<AudioManager>();
		Instance = this;
    }

    // Use this for initialization
    void Start () {
        // Try to activate the root step : it should always Activate.
        // Delay the start to give time to the user
        rootStep.Invoke("TryActivate", 2f);       
    }
    
    /// <summary>
    /// Entry point for help button
    /// </summary>
	public void PlayAudioHelp()
    {       
        AudioManager.PlaySoundClip(activatedSteps[0].audioHelpClip);
        if (activatedSteps[0].flickeringObjects != null)
        {
            foreach(FlickeringObject obj in activatedSteps[0].flickeringObjects)
            {
                obj.IsFlickering = true;
            }            
        }
    }

    #region Step Following

    public void AddActiveStep(BasicStep step)
    {
        activatedSteps.Add(step);
    }

    public void RemoveActiveStep(BasicStep step)
    {
        if(step == activatedSteps[0])
        {
            foreach (FlickeringObject obj in activatedSteps[0].flickeringObjects)
            {
                obj.IsFlickering = false;
            }
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

    public BasicStep GetStep(int id)
    {
        return GetComponentsInChildren<BasicStep>()[id];
    }

    public void ForceComplete()
    {
        activatedSteps[0].Complete();
    }
}
