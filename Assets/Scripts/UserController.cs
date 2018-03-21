using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UserState {standing, kneeling};

public class UserController : MonoBehaviour {

    public static UserController instance;

    [Header("State")]
	public UserState currentState;

	[Header ("Headset")]
    public Transform headset;
    public float playerHigh = 1.75f;

	[Header("Hands")]
	public bool holdElectrodes = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("Singleton error");
        }
    }

    void Start () {
		currentState = UserState.standing;
	}
	
	void Update () {
		if(currentState == UserState.standing && headset.position.y < 0.75f * playerHigh  )
        {
            currentState = UserState.kneeling;
        }
        else if(currentState == UserState.kneeling && headset.position.y > 0.75f * playerHigh)
        {
            currentState = UserState.standing;
        }
	}

    public void HoldElectrode()
    {
        holdElectrodes = true;
    }

}
