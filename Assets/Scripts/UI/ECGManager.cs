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

	// show flatline ecg and then complete the step
	public void StartFlatline(BasicStep step){
		StartCoroutine (PlayECG(flatline, step));
	}
	// show heartbeat ecg and then complete the step
	public void StartHeartBeat(BasicStep step){
		StartCoroutine (PlayECG(heartbeat, step));
	}

	public IEnumerator PlayECG(VideoClip _clip, BasicStep steptocomplete){
		ECGPanel.SetActive (true);

		player.clip = _clip;
		player.Play ();
		yield return new WaitForSeconds ((float) _clip.length);

		ECGPanel.SetActive (false);
		steptocomplete.Complete ();
	}

	void Start () {}

	void Update () {}
}
