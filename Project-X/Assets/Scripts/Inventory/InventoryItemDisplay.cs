using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour {

    public Text textName;
    public Image sprite;

    public delegate void InventoryItemDisplayDelage(InventoryItem item);
    public static event InventoryItemDisplayDelage onClick;

    private GameObject iventory;

    public InventoryItem item;

    void Start() {
        iventory = GameObject.Find("Inventory");

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

        switch (displayName) {

            case "Fast Sails":
                try {
                    GameObject.Find("PlayerBoat").GetComponent<BoatControllerScript>().FastSails();
                    iventory.GetComponent<Inventory>().items.Remove(item);
                }
                catch (System.Exception) { }
                break;

            case "Fuel Tank":

                PlayerPrefs.SetFloat("fuel", 100);
                iventory.GetComponent<Inventory>().items.Remove(item);
                break;

            case "Refreshments":
                iventory.GetComponent<Energy>().RefreshEnergy();
                iventory.GetComponent<Inventory>().items.Remove(item);
                break;

            case "Repair Equipment":
                try {
                    GameObject.Find("PlayerBoat").GetComponent<BoatHp>().RestoreHp();
                    iventory.GetComponent<Inventory>().items.Remove(item);
                }
                catch (System.Exception) { }
                break;

            default:
                break;

        }

    }
}
