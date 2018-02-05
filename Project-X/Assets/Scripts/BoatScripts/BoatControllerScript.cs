﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FloatObjectScript))]
public class BoatControllerScript : MonoBehaviour {

    [SerializeField]
    public float acceleration = 1f;
    public float maxBackSpeed = -50f;
    public float maxSpeed = 200f;
    public float turnSpeed = 1f;
    private Rigidbody boatRB;
    public float speed = 0;
    private Vector3 vel;

    private void Start() {
        boatRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        Inputs();
        boatRB.velocity = vel;
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



