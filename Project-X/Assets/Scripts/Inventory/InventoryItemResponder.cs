using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemResponder : MonoBehaviour {

    void Start() {
        InventoryItemDisplay.onClick += HandleonClick; //subscribe
    }

    void OnDestroy() {
        Debug.Log("Unsigned-up for onClick");
        InventoryItemDisplay.onClick -= HandleonClick; //unsubscribe
    }


    void HandleonClick(InventoryItem item) {
        Debug.Log("I listened to "+ item.displayName);
    }


}
