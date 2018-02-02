using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (FloatObjectScript))]
public class BoatControllerScript : MonoBehaviour {

    [SerializeField]
    private float acceleration;
    private float currentSpeed;
    private Rigidbody boatRB;

    private void Start()
    {
        boatRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate ()
    {
        currentSpeed = boatRB.velocity.z;
        if (Input.GetKey(KeyCode.W))
        {          
             boatRB.AddForce(transform.forward * acceleration);                              
        }
        else if (Input.GetKey(KeyCode.S))
        {
            boatRB.AddForce(-transform.forward * acceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -1f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 1f, 0f);
        }
    }        
}
