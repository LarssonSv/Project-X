using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FloatObjectScript))]
public class BoatControllerScript : MonoBehaviour {

    [SerializeField]
    private float acceleration,maxBackSpeed, 
                  maxSpeed, turnSpeed;

    private float speed = 0;

    private Rigidbody boatRB;  

    private Vector3 vel;

    private void Start() {
        boatRB = GetComponent<Rigidbody>();
    }

    public void FastSails()
    {
        acceleration += 1.5f;
        maxSpeed += 200f;
    }

    void FixedUpdate() {
        Inputs();
        boatRB.velocity = vel; // Används inte?
        boatRB.AddRelativeForce(Vector3.forward * speed);
    }

    void SpeedAdjust() {
        if (speed > 0 && speed < 2) {
            speed = 0;
        }
        else if (speed < 0 && speed > -2) {
            speed = 0;
        }
        else if (speed < 0) {
            speed = speed + acceleration;
        }
        else {
            speed = speed - acceleration;
        }
    }

    void Inputs() {
        //Check Forward and reverse
        if (Input.GetKey(KeyCode.W) && speed < maxSpeed) {
            speed = speed + acceleration;
        }
        else if (Input.GetKey(KeyCode.S) && speed > maxBackSpeed) {
            speed = speed - acceleration;
        }
        else {
            SpeedAdjust();
        }

        //Check turns
        if (Input.GetKey(KeyCode.A)) {
            if (speed < 35) {
                transform.Rotate(Vector3.down, 4f * Time.deltaTime);
            }
            else {
                transform.Rotate(Vector3.down, Time.deltaTime * speed / 30);
            }
            
        }
        else if (Input.GetKey(KeyCode.D)) {
            if (speed < 35) {
                transform.Rotate(Vector3.down, -4f * Time.deltaTime);
            }
            else {
                transform.Rotate(Vector3.down, Time.deltaTime * -speed / 30);
            }
        }
    }
}



