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
        // R�agir � l'�v�nement du Player
        Debug.Log("L'�v�nement du Player a �t� d�clench� !");
        if(this.gameObject == target) {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
