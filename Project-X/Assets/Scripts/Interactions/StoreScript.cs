using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour {

    [SerializeField]
    private GameObject item1Btn, item2Btn, item3Btn, storeCamera, menu;

    private GameObject storeText;

    private bool nearby = false, browsing = false;

    private void Start()
    {
        storeText = GameObject.Find("UI").transform.Find("StoreText").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = true;
            storeText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            browsing = false;
            nearby = false;
            storeText.SetActive(false);
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
            storeText.SetActive(false);
        }
        else if (browsing && Input.GetKeyDown(KeyCode.E))
        {
            browsing = false;
            nearby = false;
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
