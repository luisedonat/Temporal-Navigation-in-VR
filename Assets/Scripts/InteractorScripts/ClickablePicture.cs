using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ClickablePicture : MonoBehaviour
{
    public int sequenceIndex;
    private BallManagerInteractor2 ballController;
    private PictureManager pictureManager;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        ballController = FindObjectOfType<BallManagerInteractor2>();
        pictureManager = FindObjectOfType<PictureManager>();

        if (ballController == null )
        {
            Debug.LogError("BallManagerInteractor2 not found in the scene!");
        }

        if (pictureManager == null)
        {
            Debug.LogError("PictureManager not found in the scene!");
        }

        
    }

    [Obsolete]
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the grab events
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    [Obsolete]
    private void OnDestroy()
    {
        // Unsubscribe from the grab events
        grabInteractable.onSelectEntered.RemoveListener(OnGrab);
        grabInteractable.onSelectExited.RemoveListener(OnRelease);
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PlayerHand") && grabInteractable.isSelected)
        {
            Debug.Log("Picture selected: " + gameObject.name + ", Sequence Index: " + sequenceIndex);
            ballController.OnPictureTouched(sequenceIndex, gameObject);
            //ballController.RandomizeOtherPictures(gameObject);
        } else
        {
            // Debug.Log("OnTriggerEnter called on by non Player-Hand Object: " + gameObject.name);
        }            
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        Debug.Log("Object grabbed: " + gameObject.name);
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Object released: " + gameObject.name);
    }
}

