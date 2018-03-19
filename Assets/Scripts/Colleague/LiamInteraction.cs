using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiamInteraction : MonoBehaviour {

    public static LiamInteraction instance;

    public LiamBodyPart leftHand;
    public LiamBodyPart rightHand;
    public LiamBodyPart forehead;
    public LiamBodyPart chin;

    public bool isCloseEnough = false;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("Singleton error");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetIsCloseEnough(bool state)
    {
        isCloseEnough = state;
    }
}
