using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource audioSource;
    private bool audioSourceLocked = false;

    // Use this for initialization
    void Start () {
        if(audioSource == null)
        {
            Debug.LogWarning("No audio will be played if you don't select an audio source.");
        }
    }
	
    /// <summary>
    /// Play the sound clip parameter
    /// </summary>
    /// <param name="clipToPlay">Sound clip to play</param>
    /// <param name="isStoppable">If false, you can't stop the clip from being played.</param>
    public void PlaySoundClip(AudioClip clipToPlay, bool lockAudioSource = false)
    {
        if (!audioSourceLocked && clipToPlay != null)
        {
            StopCoroutine("AudioClipCallback");
            audioSource.clip = clipToPlay;
            audioSource.Play();

            if (lockAudioSource)
            {
                StartCoroutine("AudioClipCallback", clipToPlay.length);
            }
        }

    }
    IEnumerator AudioClipCallback(float time)
    {
        audioSourceLocked = true;
        yield return new WaitForSeconds(time);
        audioSourceLocked = false;
    }
}
