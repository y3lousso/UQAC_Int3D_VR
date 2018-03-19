using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringObject : MonoBehaviour {

    public bool IsFlickering { get; set; }

    public Color flickeringColor;
    public AnimationCurve flickeringCurve;
    private MeshRenderer meshRenderer;
    private VRTK.VRTK_InteractableObject interactableObject;
    private Color baseColor;

    private float time = 0f;

    public void OnEnable()
    {
        interactableObject = GetComponent<VRTK.VRTK_InteractableObject>();
        if (interactableObject != null)
        {
            interactableObject.InteractableObjectTouched += InteractableObject_InteractableObjectTouched;
            interactableObject.InteractableObjectUntouched += InteractableObject_InteractableObjectUntouched;
        }
    }

    public void OnDisable()
    {
        if (interactableObject != null)
        {
            interactableObject.InteractableObjectTouched -= InteractableObject_InteractableObjectTouched;
            interactableObject.InteractableObjectUntouched -= InteractableObject_InteractableObjectUntouched;
        }
    }

    private void InteractableObject_InteractableObjectTouched(object sender, VRTK.InteractableObjectEventArgs e)
    {
        interactableObject.touchHighlightColor = Color.yellow;
    }

    private void InteractableObject_InteractableObjectUntouched(object sender, VRTK.InteractableObjectEventArgs e)
    {
        interactableObject.touchHighlightColor = baseColor;
    }

    // Use this for initialization
    void Start () {
        IsFlickering = false;
        meshRenderer = GetComponent<MeshRenderer>();
        baseColor = meshRenderer.material.GetColor("_Color");
        meshRenderer.material.EnableKeyword("_EMISSION");
    }
	
	// Update is called once per frame
	void Update () {
        if (IsFlickering)
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
