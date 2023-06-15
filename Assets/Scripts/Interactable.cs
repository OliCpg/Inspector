using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInteraction playerObject = GameObject.FindObjectOfType<PlayerInteraction>();
        playerObject.InteractionEvent.AddListener(HandleInteractionEvent);
    }

    private void HandleInteractionEvent() {
        // R�agir � l'�v�nement du Player
        Debug.Log("L'�v�nement du Player a �t� d�clench� !");
    }
}
