using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour {

    [SerializeField]
    private GameObject loot;
    private GameObject treasureText;

    private bool nearby = false;

    private void Start()
    {
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
            Debug.Log("you loot some stuff");
            treasureText.SetActive(false);
            Destroy(gameObject);
        }
	}
}
