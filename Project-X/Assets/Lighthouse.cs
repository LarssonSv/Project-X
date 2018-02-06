using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {
    [SerializeField]
    private GameObject lighthouseText, player;
    private GameObject clone, ui;

    private bool nearby = false, lit = false;

	void Start ()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = true;
            clone = Instantiate(lighthouseText);
            clone.transform.SetParent(ui.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = false;
            Destroy(clone.gameObject);
        }
    }

    void Update ()
    {
        if (nearby && Input.GetKeyDown(KeyCode.E))
        {            
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(clone.gameObject);
            StartCoroutine("Activate");
        }
        else if (lit && Input.GetKeyDown(KeyCode.E))
        {
            nearby = false;
            Destroy(clone.gameObject);
        }
    }

    IEnumerator Activate()
    {
        //activate camera
        //light lighthouse
        
        yield return new WaitForSeconds(5);
        lit = true;
        //press E to continue
    }
}
