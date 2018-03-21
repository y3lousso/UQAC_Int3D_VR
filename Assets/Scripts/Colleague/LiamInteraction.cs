using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiamInteraction : MonoBehaviour {

    public static LiamInteraction instance;

    [Header("BodyParts")]
    public LiamBodyPart leftHand;
    public LiamBodyPart rightHand;
    public LiamBodyPart forehead;
    public LiamBodyPart chin;
    public LiamBodyPart mouth;

    [Header("States")]
    public bool isCloseEnough = false;
    public bool isListenningBreathing = false;

    [Header("Tie")]
    public GameObject tie;
    public bool isTieRemoved = false;

    [Header("Shirt")]
    public SkinnedMeshRenderer shirt;
    public Collider shirtCollider;
    public bool isShirtRemoved = false;

    [Header("Electrode")]
    public bool isElectrodeLeftPlaced = false;
    public bool isElectrodeRightPlaced = false;

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
        shirtCollider.gameObject.SetActive(false);
    }

    public void SetIsCloseEnough(bool state)
    {
        isCloseEnough = state;
    }

    public void SetIsListenningBreathing(bool state)
    {
        isListenningBreathing = state;
    }

    public void RemoveTie()
    {
        tie.SetActive(false);
        shirtCollider.gameObject.SetActive(true);
        isTieRemoved = true;
    }

    public void RemovedShirt()
    {
        shirt.material.color = Color.black;
        shirtCollider.gameObject.SetActive(false);
        isShirtRemoved = true;
    }

    public void PlacedElectrodeLeft()
    {
        isElectrodeLeftPlaced = true;
    }

    public void PlacedElectrodeRight()
    {
        isElectrodeRightPlaced = true;
    }
}
