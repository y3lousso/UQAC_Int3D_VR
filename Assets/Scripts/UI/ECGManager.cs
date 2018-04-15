using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ECGManager : MonoBehaviour {

	[SerializeField] private GameObject ECGPanel;

	[SerializeField] private VideoClip flatline;
	[SerializeField] private VideoClip heartbeat;

	[SerializeField] private VideoPlayer player;
	[SerializeField] private AudioSource audiosource;

    public Coroutine currentCoroutine;

	// show flatline ecg and then complete the step
	public void StartFlatline(BasicStep step){
        if (currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(PlayECG(flatline, step));
        }
	}
	// show heartbeat ecg and then complete the step
	public void StartHeartBeat(BasicStep step){
        Debug.Log("Playing beat");
        if (currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(PlayECG(heartbeat, step));
        }
	}

	public IEnumerator PlayECG(VideoClip _clip, BasicStep steptocomplete){
		ECGPanel.SetActive (true);

		player.clip = _clip;
		player.Play ();
		yield return new WaitForSeconds ((float) _clip.length);

		ECGPanel.SetActive (false);
		steptocomplete.Complete ();
        currentCoroutine = null;
    }

	void Start () {}

	void Update () {}
}
