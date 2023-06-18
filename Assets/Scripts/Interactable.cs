using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInteraction playerObject = GameObject.FindObjectOfType<PlayerInteraction>();
        //playerObject.InteractionEvent.AddListener(HandleInteractionEvent);
        playerObject.InteractionEvent += HandleInteractionEvent;

        GetComponent<MeshRenderer>().enabled = false;

    }

    private void HandleInteractionEvent(GameObject target) {
        // Réagir à l'événement du Player
        Debug.Log("L'événement du Player a été déclenché !");
        if(this.gameObject == target) {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
