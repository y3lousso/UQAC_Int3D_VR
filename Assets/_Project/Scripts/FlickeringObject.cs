using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringObject : MonoBehaviour {

    public bool isFlickering = false;

    public Color flickeringColor;
    public AnimationCurve flickeringCurve;
    private MeshRenderer meshRenderer;

    private float time = 0f;

    public void SetFlickering(bool state)
    {
        isFlickering = state;
    }

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.EnableKeyword("_EMISSION");
    }
	
	// Update is called once per frame
	void Update () {
        if (isFlickering)
        {
            time += Time.deltaTime;
            Color color = Color.Lerp(Color.black, flickeringColor, flickeringCurve.Evaluate(time));
            meshRenderer.material.SetColor("_EmissionColor", color);
        }
        else
        {
            meshRenderer.material.SetColor("_EmissionColor", Color.black);
        }
	}
}
