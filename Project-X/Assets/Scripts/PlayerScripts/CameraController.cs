using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    
    public Transform target;
    public Vector3 offsetPos;
    public float moveSpeed = 5;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    Vector3 targetPos;
 



	
	void FixedUpdate () {
        MovieWithTarget();
        RotateTowardsMouse(); 
    }

    void MovieWithTarget() {
        targetPos = target.position + offsetPos;
        transform.position = targetPos;
    }

    void RotateTowardsMouse() {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }


    


        


}

