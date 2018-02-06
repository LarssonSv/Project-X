using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

    [SerializeField]
    private GameObject goAshoreText, setSailText, playerBoat,
                       spawnPosition, playerCharacter, dockedBoat;

    private GameObject ui, clone;

    private bool docked = false, nearby = false;

    private Rigidbody boatRB;

    private void Start()
    {
        boatRB = playerBoat.GetComponent<Rigidbody>();
        ui = GameObject.FindGameObjectWithTag("UI");
    }

    //Slår på/av texten när båten kommer in/ut ur kollisionsboxen.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBoat") || other.CompareTag("Player"))
        {
            nearby = true;
            if (!docked)
            {
                clone = Instantiate(goAshoreText);               
            }
            else
            {
                clone = Instantiate(setSailText);
            }
            clone.transform.SetParent(ui.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerBoat") || other.CompareTag("Player"))
        {
            nearby = false;           
            Destroy(clone.gameObject);                  
        }
    }

    //Lägg till eller åk ifrån ö.
    private void Update()
    {
        if (nearby && Input.GetKeyDown(KeyCode.E) && !docked)
        {
            docked = true;
            Destroy(clone.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("PlayerBoat"));
            Instantiate(playerCharacter, spawnPosition.transform.position, spawnPosition.transform.rotation);
            Instantiate(dockedBoat, transform.position, transform.rotation);
        }
        else if (nearby && Input.GetKeyDown(KeyCode.E) && docked)
        {          
            docked = false;
            Destroy(clone.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("Idle"));
            Instantiate(playerBoat, transform.position, transform.rotation);
        }
    }
}
