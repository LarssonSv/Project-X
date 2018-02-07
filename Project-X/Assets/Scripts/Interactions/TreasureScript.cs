using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureScript : MonoBehaviour {

    [SerializeField]
    private InventoryItem loot;

    private GameObject treasureText;

    private Inventory inventory;

    private bool nearby = false;

    private void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        //Eftersom TreasureText är inaktiverat vid start går jag via den aktiva föräldern.
        treasureText = GameObject.Find("UI").transform.Find("TreasureText").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBoat")
        {
            treasureText.SetActive(true);
            nearby = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerBoat")
        {
            treasureText.SetActive(false);
            nearby = false;
        }        
    }

    void Update ()
    {
        if (nearby && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(loot);
            Debug.Log("you loot a " + loot.displayName + ".");
            treasureText.SetActive(false);
            Destroy(gameObject);
        }
	}
}
