using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiamBodyPart : MonoBehaviour {

    public bool isTouching = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ViveController"))
        {
            //vibration
            isTouching = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ViveController"))
        {
            isTouching = false;
        }
    }
}
