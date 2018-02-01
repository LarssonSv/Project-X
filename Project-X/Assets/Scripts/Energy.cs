using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {

    [SerializeField]
    Image energyBar;

    float energy;

    private void Start() {
        energy = 100;
        InvokeRepeating("DecayEnergy", 1f, 5f);
    }

    private void Update() {
        energyBar.fillAmount = energy / 100;
    }

    private void DecayEnergy () {
        energy -= 1;
    }
}
