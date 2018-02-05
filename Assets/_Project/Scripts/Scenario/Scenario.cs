using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour {

    [Header("Scenario Management")]
    public List<BasicStep> rootSteps;
    public List<BasicStep> activatedSteps = new List<BasicStep>();
    public List<BasicStep> completedSteps = new List<BasicStep>();

    [Header("Step Instructions")]
    public AudioSource audioSource;
    private bool audioSourceLocked = false;

    // Use this for initialization
    void Start () {
	    foreach(BasicStep step in rootSteps)
        {
            step.TryActivate();
        }	
	}
	
	public void OnHelpButtonPressed()
    {
        PlaySoundClip(activatedSteps[0].audioHelpClip, false);
        activatedSteps[0].SetFlickerAssociatedObject(true);
    }

    #region Audio
    /// <summary>
    /// Play the sound clip parameter
    /// </summary>
    /// <param name="clipToPlay">Sound clip to play</param>
    /// <param name="isStoppable">If false, you can't stop the clip from being played.</param>
    public void PlaySoundClip(AudioClip clipToPlay, bool isUnstoppable)
    {
        if (!audioSourceLocked && clipToPlay != null)
        {
            StopCoroutine("AudioClipCallback");
            audioSource.clip = clipToPlay;
            audioSource.Play();

            if (isUnstoppable)
            {
                StartCoroutine("AudioClipCallback", clipToPlay.length);
            }
        }
        
    }
    IEnumerator AudioClipCallback(float time)
    {
        audioSourceLocked = true;
        yield return new WaitForSeconds(time);
        // clip is over
        audioSourceLocked = false;
    }
    #endregion

    #region Step Following
    public void AddActiveStep(BasicStep step)
    {
        activatedSteps.Add(step);
    }
    public void RemoveActiveStep(BasicStep step)
    {
        if(step == activatedSteps[0])
        {
            activatedSteps[0].SetFlickerAssociatedObject(false);
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

}
