using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField]
    Image bar;
    Rigidbody rb;
    [SerializeField]
    float force = 200f;
    [SerializeField]
    float cost = 0.25f;

    float fuel;

    private void Start()
    {
        fuel = 50;
        fuel = PlayerPrefs.GetFloat("fuel");
        rb = GetComponent<Rigidbody>();
        bar = GameObject.FindGameObjectWithTag("FuelBar").GetComponent<Image>();
    }


    private void Boost()
    {
        rb.AddRelativeForce(transform.forward * force * Time.deltaTime);
        fuel = fuel - cost;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            Boost();
        }
        PlayerPrefs.SetFloat("fuel", fuel);
        bar.fillAmount = fuel / 100;
    }
}




    