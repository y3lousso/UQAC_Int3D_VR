using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isOpen = false;
    public Collider col;
    public AnimatePosition animatePosition;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleDoor()
    {
        if (isOpen) // Close
        {
            animatePosition.ReverseAnimation();
            col.enabled = true;
            isOpen = false;
        }
        else // Open
        {
            animatePosition.StartAnimation();
            col.enabled = false;
            isOpen = true;
        }
    }
}
