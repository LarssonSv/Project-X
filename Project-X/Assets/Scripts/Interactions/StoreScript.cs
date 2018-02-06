using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour {

    [SerializeField]
    private GameObject menu, storeCamera, storeText, item1Btn, item2Btn, item3Btn;

    private GameObject clone, ui;

    private bool nearby = false, browsing = false;

    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = true;
            clone = Instantiate(storeText);
            clone.transform.SetParent(ui.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            browsing = false;
            nearby = false;
            Destroy(clone.gameObject);
            storeCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().enabled = false;
            menu.SetActive(false);
        }
    }

    private void Update()
    {
        if (nearby && !browsing && Input.GetKeyDown(KeyCode.E))
        {
            browsing = true;
            storeCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().enabled = true;
            menu.SetActive(true);
            Destroy(clone.gameObject);
        }
        else if (browsing && Input.GetKeyDown(KeyCode.E))
        {
            browsing = false;
            nearby = false;
            Destroy(clone.gameObject);
            storeCamera.GetComponent<Cinemachine.CinemachineVirtualCamera>().enabled = false;
            menu.SetActive(false);
        }
    }

    public void BuyItem(int item)
    {
        switch (item)
        {
            case 1:
                //giff player item 1;
                Debug.Log("You bought item 1!");
                item1Btn.SetActive(false);
                break;
            case 2:
                //giff player item 2;
                Debug.Log("You bought item 2!");
                item2Btn.SetActive(false);
                break;
            case 3:
                //giff player item 3;
                Debug.Log("You bought item 3!");
                item3Btn.SetActive(false);
                break;
            default:
                break;
        }
    }
}
