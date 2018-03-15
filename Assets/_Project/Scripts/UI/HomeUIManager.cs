using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnStartButtonPressed()
    {
        SceneManager.instance.ChangeScene("FirstAid");
    }

    public void OnOptionButtonPressed()
    {
        // Open settings panel
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

}
