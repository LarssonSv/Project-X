using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour {

    [SerializeField]
    private GameObject playerBoat, spawnPosition, playerCharacter, dockedBoat;

    private GameObject goAshoreText, setSailText;

    private bool docked = true, nearby = false;

    private void Start()
    {
        goAshoreText = GameObject.Find("UI").transform.Find("GoAshoreText").gameObject;
        setSailText = GameObject.Find("UI").transform.Find("SetSailText").gameObject;
    }

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
            goAshoreText.SetActive(false);
            setSailText.SetActive(false);
        }
    }

    //Lägg till eller åk ifrån ö.
    private void Update()
    {
        if (nearby && Input.GetKeyDown(KeyCode.E) && !docked)
        {
            GameObject.Find("CheckPoint").GetComponent<CheckPointScript>().NewSpawnPoint(gameObject);
            docked = true;
            goAshoreText.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("PlayerBoat"));
            Instantiate(playerCharacter, spawnPosition.transform.position, spawnPosition.transform.rotation);
            Instantiate(dockedBoat, transform.position, transform.rotation);
        }
        else if (nearby && Input.GetKeyDown(KeyCode.E))
        {          
            docked = false;
            setSailText.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(GameObject.FindGameObjectWithTag("Idle"));
            Instantiate(playerBoat, transform.position, transform.rotation);
        }
    }
}
