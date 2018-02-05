using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FloatObjectScript))]
public class BoatControllerScript : MonoBehaviour {

    [SerializeField]
    public float acceleration = 1f;
    public float maxBackSpeed = -50f;
    public float maxSpeed = 200f;
    private Rigidbody boatRB;
    public float speed = 0;
    private Vector3 vel;

    private void Start() {
        boatRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {

        if (Input.GetKey(KeyCode.W)) {
            if (speed < maxSpeed) {
                speed = speed + acceleration;
            }
        } else if (Input.GetKey(KeyCode.S)) {

            if (speed > maxBackSpeed) {
                speed = speed - acceleration;
            }

        } else {
            if (speed < acceleration + 2 && speed > 0) {
                speed = 0;
            } else if (speed < 0 && speed > -3) {
                speed = 0;
            } else {
                if (speed > 0) {
                    speed = speed - acceleration;
                }
                else if (speed < 0) {
                    speed = speed + acceleration;
                }
                
            }

        }
    

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0f, -1f, 0f);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0f, 1f, 0f);
        }
        boatRB.velocity = vel;
        boatRB.AddRelativeForce(Vector3.forward* speed);
    }
}
