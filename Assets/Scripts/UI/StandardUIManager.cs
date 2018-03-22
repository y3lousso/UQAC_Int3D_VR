using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardUIManager : MonoBehaviour {

    public GameObject AppTab;
    public GameObject SoundTab;
    public Text timeText;
    private float currentTime = 0f;

	// Use this for initialization
	void Start () {
        CloseTabs();
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        timeText.text = currentTime.ToString("0.0");
	}

    public void OnAppButtonPressed()
    {
        CloseTabs();
        AppTab.SetActive(true);
    }

    public void OnSoundButtonPressed()
    {
        CloseTabs();
        SoundTab.SetActive(true);
    }

    public void OnExitButtonPressed()
    {
        SceneManager.instance.ChangeScene("Menu");
    }

    public void CloseTabs()
    {
        AppTab.SetActive(false);
        SoundTab.SetActive(false);
    }
}
