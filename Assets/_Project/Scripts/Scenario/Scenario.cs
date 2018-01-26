using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour {

    [Header("Scenario Management")]
    public List<BasicStep> steps;
    public List<BasicStep> rootSteps;

    [Header("Step Instructions")]
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
