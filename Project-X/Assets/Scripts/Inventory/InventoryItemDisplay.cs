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
        
            switch (displayName)
            {
                case "Dagger":
                    Debug.Log("Works");
                    break;

                case "Fast Sails":

                    break;

                case "Fuel Tank":

                    break;

                case "Refreshments":

                    break;

                case "Repair Equipment":
                    try
                    {
                        Debug.Log("works");
                        GameObject.Find("PlayerBoat").GetComponent<BoatHp>().RestoreHp();
                        GameObject.Find("Inventory").GetComponent<Inventory>().items.Remove(item);
                    }
                    catch (System.Exception) { }
                    Debug.Log("crash");
                    break;

                case "Sword":

                    break;

                default:
                    break;
            
        } 

    }
}
