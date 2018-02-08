using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeachBubble : MonoBehaviour {

    [SerializeField]
    GameObject speachbubble;

    public void FeedCanvas(string displayName, string speach) {

        if (speachbubble.activeInHierarchy == false)
        {
            speachbubble.SetActive(true);
            Text name = GameObject.FindGameObjectWithTag("speachName").GetComponent<Text>();
            name.text = displayName;

            Text mainText = GameObject.FindGameObjectWithTag("speachText").GetComponent<Text>();
            mainText.text = speach;
        }
        else
        {
            speachbubble.SetActive(false);
        }
    }

    public void Deactivate()
    {
        speachbubble.SetActive(false);
    }

}
