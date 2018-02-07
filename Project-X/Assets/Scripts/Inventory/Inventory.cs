using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<InventoryItem> items = new List<InventoryItem>();
    public InventoryDisplay inventoryDisplayPrefab;
    public KeyCode openInv;

    bool open = false;

    void Start() {
      //  InventoryDisplay inventory = (InventoryDisplay)Instantiate(inventoryDisplayPrefab);
      //  inventory.Prime(items);
    }

    void Update() {
        ListenForInv();
        KeyListen();
    }

    void ListenForInv() {
        if (GameObject.FindGameObjectWithTag("Inventory")) {
            open = true;
        }
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    void KeyListen() {
        if (Input.GetKeyDown(openInv)) {
            if (open == false) {
                InventoryDisplay inventory = (InventoryDisplay)Instantiate(inventoryDisplayPrefab);
                inventory.Prime(items);
            } else {
                Destroy(GameObject.FindGameObjectWithTag("Inventory"));
                open = false;
            }
        }

    }
}
