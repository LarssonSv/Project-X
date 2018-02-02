using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [Header("Publics")]
    public float velocity = 5;
    public float turnSpeed = 10;
    public float maxGroundAngle = 120;
    public float heightPadding = 0.05f;
    public float height = 0.5f;
    public float groundAngle;
    public LayerMask ground;

    //Private
    Vector2 input;
    float angle;
    Rigidbody rb;
    Quaternion targetRotation;
    Vector3 forward;
    RaycastHit hitInfo;
    bool grounded;


    void Start() {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }


    void Update() {

        GetInput();
        CalculateDirection();
        CalculateForward();
        ApplyGravity();
        CalculateGroundAngle();
        CheckGround();
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) {
            rb.velocity = 0f * Vector3.forward;
        } else {
            Rotate();
            Move();

        }



    }

    void ApplyGravity() {
        if (!grounded) {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
        
    }

    //Input based keys
    void GetInput() {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void CalculateDirection() {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
    }

    //Rotate toward angle
    void Rotate() {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }


    //Move Object
    void Move() {
        if (groundAngle >= maxGroundAngle) {
            rb.velocity = 0f * Vector3.forward;
        } else {
            rb.velocity = forward * velocity;
        }


    }

    //If player is not gounded, forward will be equal to transfrom forward
    //Use a cross product to determine the new forward vector
    void CalculateForward() {
        if (!grounded) {
            forward = transform.forward;
            return;
        }

        forward = Vector3.Cross(hitInfo.normal, -transform.right);
    }

    void CalculateGroundAngle() {
        if (!grounded) {
            groundAngle = 30;
            return;
        }
        groundAngle = Vector3.Angle(hitInfo.normal, transform.forward);
    }

    void CheckGround() {
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, height + heightPadding, ground)) {
            grounded = true;
        } else {
            grounded = false;
        }
    }
}