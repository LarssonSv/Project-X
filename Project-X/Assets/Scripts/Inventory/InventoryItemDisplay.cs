using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour {

    public Text textName;
    public Image sprite;

    public delegate void InventoryItemDisplayDelage(InventoryItem item);
    public static event InventoryItemDisplayDelage onClick;

    public InventoryItem item;

    void Start() {
        if (item != null) {
            Prime(item);
        }
    }

    public void Prime(InventoryItem item) {
        this.item = item;
        if (textName != null) {
            textName.text = item.displayName;
        }
        if (sprite != null) {
            sprite.sprite = item.sprite;
        }
    }

    public void Click() {
        string displayName = "nothing";
        if (item != null) {
            displayName = item.displayName;
        }
        Debug.Log("Clicked!" + displayName);
        if (onClick != null) {
            onClick.Invoke(item);
        } else {
            Debug.Log("Nobody was listening to" + displayName);
        }

    }
}
