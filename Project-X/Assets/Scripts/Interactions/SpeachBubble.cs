using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeachBubble : MonoBehaviour {

    [SerializeField]
    Canvas speachBubblePrefab;

    private Canvas clone;

    public void OpenBubble() {

        if (clone == null) {
            clone = Instantiate(speachBubblePrefab);
            
        }
        else {

            Destroy(clone.gameObject);

        }

    }

    public void FeedCanvas(string displayName, string speach) {

        Text name = GameObject.FindGameObjectWithTag("speachName").GetComponent<Text>();
        name.text = displayName;

        Text mainText = GameObject.FindGameObjectWithTag("speachText").GetComponent<Text>();
        mainText.text = speach;
    }

}
