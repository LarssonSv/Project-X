using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour {
    [SerializeField]
    private GameObject player, hinge, ani, spawnPoint;
    private GameObject lighthouseText, lighthouseLitText;

    private bool nearby = false, lit = false;

	void Start ()
    {       
        lighthouseText = GameObject.Find("UI").transform.Find("LighthouseText").gameObject;
        lighthouseLitText = GameObject.Find("UI").transform.Find("LighthouseLitText").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!lit && other.gameObject.CompareTag("Player"))
        {
            nearby = true;
            lighthouseText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!lit && other.gameObject.CompareTag("Player"))
        {
            nearby = false;
            lighthouseText.SetActive(false);
        }
    }

    void Update ()
    {
        if (nearby && Input.GetKeyDown(KeyCode.E))
        {
            nearby = false;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            lighthouseText.SetActive(false);
            StartCoroutine("Activate");
        }
        else if (lit && Input.GetKeyDown(KeyCode.E))
        {
            ani.SetActive(false);
            lighthouseLitText.SetActive(false);
            Destroy(this);
            Instantiate(player, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

    IEnumerator Activate()
    {
        ani.SetActive(true);
        hinge.SetActive(true);
        
        yield return new WaitForSeconds(6);
        lit = true;
        lighthouseLitText.SetActive(true);
    }
}
