using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    [SerializeField]
    Image interactIcon;
    public string scriptToRun;
    public KeyCode use;
    public int limit = 1;
    int timesUsed = 0;
    GameObject inv;
    public string name;
    public string maintext;

  

    

    void Start() {
        interactIcon.fillAmount = 0;
        inv = GameObject.FindGameObjectWithTag("Inventory");
    }


    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && timesUsed < limit) {
            interactIcon.fillAmount = 1;
            if (Input.GetKeyDown(use)) {
                Invoke(scriptToRun, 0f);
                timesUsed += 1;
            }
        }

    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            interactIcon.fillAmount = 0;
        }
        inv.GetComponent<SpeachBubble>().Deactivate();
        Destroy(gameObject);
    }

    void Test() {
        Debug.Log("Works");
    }


    void SpeachBubble()
    {
        inv.GetComponent<SpeachBubble>().FeedCanvas(name, maintext);
    }

 

}
