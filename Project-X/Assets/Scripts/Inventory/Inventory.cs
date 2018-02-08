using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour {

    public List<InventoryItem> items = new List<InventoryItem>();
    public InventoryDisplay inventoryDisplayPrefab;
    public KeyCode openInv;
    protected int money = 0;

    [SerializeField]
    private int startMoney;
  
    private  GameObject moneyText;

    bool open = false;

    void Start() {
        moneyText = GameObject.Find("MoneyText");
        ChangeMoney("Add", startMoney);
    }

    void Update() {
        ListenForInv();
        KeyListen();
    }

    public int GetMoney()
    {
        return money;
    }

    public void ChangeMoney(string change, int amount)
    {
        if (change == "Add")
        {
            money += amount;
        }
        else if (change == "Remove")
        {
            money -= amount;
        }
        moneyText.GetComponent<TextMeshProUGUI>().text = "Money: " + money;
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
