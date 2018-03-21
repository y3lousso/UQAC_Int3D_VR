using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VRTK.VRTK_InteractableObject))]
public class LiamBodyPart : MonoBehaviour {

    public bool isHolding = false;
    [SerializeField] private VRTK.VRTK_InteractableObject interactableObject;

    private void OnEnable()
    {
        interactableObject.InteractableObjectUsed += InteractableObject_InteractableObjectUsed;
        interactableObject.InteractableObjectUnused += InteractableObject_InteractableObjectUnused;
    }

    private void OnDisable()
    {
        interactableObject.InteractableObjectUsed -= InteractableObject_InteractableObjectUsed;
        interactableObject.InteractableObjectUnused -= InteractableObject_InteractableObjectUnused;
    }

    private void InteractableObject_InteractableObjectUsed(object sender, VRTK.InteractableObjectEventArgs e)
    {
        isHolding = true;
    }

    private void InteractableObject_InteractableObjectUnused(object sender, VRTK.InteractableObjectEventArgs e)
    {
        isHolding = false;
    }

}
