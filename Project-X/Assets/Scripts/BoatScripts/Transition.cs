using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

    [SerializeField]
    private GameObject goAshoreText,setSailText, playerBoat, 
                       spawnPosition, playerCharacter, dockedBoat;

    private bool docked = false, nearby = false;

    private Rigidbody boatRB;

    private void Start()
    {
        boatRB = playerBoat.GetComponent<Rigidbody>();
    }

    //Slår på/av texten när båten kommer in/ut ur kollisionsboxen.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBoat") || other.CompareTag("Player"))
        {
            nearby = true;
            if (!docked)
            {
                goAshoreText.SetActive(true);
            }
            else
            {
                setSailText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerBoat") || other.CompareTag("Player"))
        {
            nearby = false;
            if (!docked)
            {
                goAshoreText.SetActive(false);
            }
            else
            {
                setSailText.SetActive(false);
            }           
        }
    }

    //Lägg till eller åk ifrån ö.
    private void Update()
    {
        if (nearby && Input.GetKeyDown(KeyCode.E) && !docked)
        {
            goAshoreText.SetActive(false);                             
            docked = true;                      
            Destroy(GameObject.FindGameObjectWithTag("PlayerBoat"));
            Instantiate(playerCharacter, spawnPosition.transform.position, spawnPosition.transform.rotation);
            Instantiate(dockedBoat, transform.position, transform.rotation);
        }
        else if (nearby && Input.GetKeyDown(KeyCode.E) && docked)
        {
            setSailText.SetActive(false);
            docked = false;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("Idle"));
            Instantiate(playerBoat, transform.position, transform.rotation);
        }
    }
}
