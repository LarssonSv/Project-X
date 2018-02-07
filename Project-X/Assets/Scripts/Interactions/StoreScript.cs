using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreScript : MonoBehaviour {

    [SerializeField]
    private GameObject item1Btn, item2Btn, item3Btn, storeCamera, menu;
    private GameObject storeText;

    [Space(5)]

    [SerializeField]
    private InventoryItem item1, item2, item3;
    private Inventory inventory;

    [Space(5)]

    [SerializeField]
    private TextMeshPro item1CostText, item2CostText, item3CostText;

    [Space(5)]

    [SerializeField]
    private int item1Cost, item2Cost, item3Cost;

    private bool nearby = false, browsing = false;

    private void Start()
    {
        item1CostText.text = item1Cost.ToString();
        item2CostText.text = item2Cost.ToString();
        item3CostText.text = item3Cost.ToString();
        storeText = GameObject.Find("UI").transform.Find("StoreText").gameObject;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
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
                if (inventory.GetMoney() >= item1Cost)
                {
                    inventory.ChangeMoney("Remove", item1Cost);
                    inventory.AddItem(item1);
                    Debug.Log("You bought a " + item1.name.ToString() + ".");
                    item1Btn.SetActive(false);
                }
                
                break;

            case 2:
                if (inventory.GetMoney() >= item2Cost)
                {
                    inventory.ChangeMoney("Remove", item2Cost);
                    inventory.AddItem(item2);
                    Debug.Log("You bought a " + item2.name.ToString() + ".");
                    item2Btn.SetActive(false);
                }
                break;

            case 3:
                if (inventory.GetMoney() >= item3Cost)
                {
                    inventory.ChangeMoney("Remove", item3Cost);
                    inventory.AddItem(item3);
                    Debug.Log("You bought a " + item3.name.ToString() + ".");
                    item3Btn.SetActive(false);
                }                
                break;

            default:
                break;
        }
    }
}
