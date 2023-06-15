using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 1f;
    [SerializeField] private string interactionTag;

    private bool isInteracting = false;
    public UnityEvent InteractionEvent;

    void Update()
    {
        if (isInteracting) {
            Debug.Log("Interaction request...");
            Ray interationRay = new Ray(transform.position, transform.forward);
            if(Physics.Raycast(interationRay, out RaycastHit interactionHit, interactionRange)) {
                
                GameObject hitObject = interactionHit.collider.gameObject;

                if (hitObject.CompareTag(interactionTag)){
                    InteractionEvent?.Invoke();
                }
            }
        }
        isInteracting=false;
    }

    private void Testing_OnInteraction(object sender, EventArgs e) {
        Debug.Log("Interact");
    }

    public void OnInteract(InputAction.CallbackContext context) {
        if (context.canceled) {
            isInteracting = true;
        }
    }
}
