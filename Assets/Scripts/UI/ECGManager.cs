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

	public void StartFlatline(){
		StartCoroutine (PlayECG(flatline));
	}

	public void StartHeartBeat(){
		StartCoroutine (PlayECG(heartbeat));
	}

	public IEnumerator PlayECG(VideoClip _clip){
		ECGPanel.SetActive (true);

		player.clip = _clip;
		//SET audio to audiosource
		player.Play ();
		yield return new WaitForSeconds ((float) _clip.length);

		ECGPanel.SetActive (false);
	}

	void Start () {}

	void Update () {
		if (Input.GetKeyDown ("p"))
			StartFlatline ();
	}
}
