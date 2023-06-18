using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private PlayerInteraction PlayerObject;
    [SerializeField] private List<GameObject> gaobjectList = new List<GameObject>();
    private HashSet<GameObject> gameObjectHashList = new HashSet<GameObject>();

    private void Start() {
        // Souscription à l'événement InteractionEvent
        PlayerObject.InteractionEvent += AddGameObjectToList;
    }

    private void OnDestroy() {
        // Désabonnement de l'événement InteractionEvent lors de la destruction du GameManager
        PlayerObject.InteractionEvent -= AddGameObjectToList;
    }

    private void AddGameObjectToList(GameObject gameObject) {
        // Ajout du GameObject reçu à la liste
        gameObjectHashList.Add(gameObject);
        gaobjectList = gameObjectHashList.ToList();

        if (gameObjectHashList.Count >= 3) {
            Debug.Log("BRAVO VOUS AVEZ TOUT TROUVE !!!");
        }  
    }
}
