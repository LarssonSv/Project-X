using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {

    [SerializeField]
    Image bar;

    float fuel;

    private void Start() {
        fuel = 50;
    }

    private void Update() {
        bar.fillAmount = fuel / 100;
    }

}
