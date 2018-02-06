using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {
    [SerializeField]
    private GameObject lighthouseText, player, lighhouseLitText, hinge, ani, spawnPoint;
    private GameObject clone, ui;

    private bool nearby = false, lit = false;

	void Start ()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!lit && other.gameObject.CompareTag("Player"))
        {
            nearby = true;
            clone = Instantiate(lighthouseText);
            clone.transform.SetParent(ui.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!lit && other.gameObject.CompareTag("Player"))
        {
            nearby = false;
            Destroy(clone.gameObject);
        }
    }

    void Update ()
    {
        if (nearby && Input.GetKeyDown(KeyCode.E))
        {
            nearby = false;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(clone.gameObject);
            StartCoroutine("Activate");
        }
        else if (lit && Input.GetKeyDown(KeyCode.E))
        {
            ani.SetActive(false);
            Destroy(clone.gameObject);
            Instantiate(player, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

    IEnumerator Activate()
    {
        ani.SetActive(true);
        hinge.SetActive(true);
        
        yield return new WaitForSeconds(6);
        lit = true;
        clone = Instantiate(lighhouseLitText);
        clone.transform.SetParent(ui.transform);
    }
}
