using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStep : MonoBehaviour {

    [Header("Scenario Management")]
    public Scenario scenario;
    public List<BasicStep> previousSteps;
    public List<BasicStep> nextSteps;
    public bool isActivated = false;
    public bool isCompleted = false;

    [Header("Step Instructions")]
    public AudioClip audioStartClip;
    public AudioClip audioHelpClip;
    public FlickeringObject flickeringObject;


    public void Awake()
    {
        scenario = GetComponentInParent<Scenario>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
