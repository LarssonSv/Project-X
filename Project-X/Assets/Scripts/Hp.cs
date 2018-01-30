using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour {

    [SerializeField]
    Image bar;

    float hp;

    private void Start() {
        hp = 100;
    }

    private void Update() {
        bar.fillAmount = hp / 100;
    }

}
