using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    
    
    public Vector3 offsetPos;
    public float moveSpeed = 5;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    public Transform player;
    private float pitch = 0.0f;
    Vector3 targetPos;

    private void Start() {
        
        

    }



    void FixedUpdate () {
        MovieWithTarget();
        RotateTowardsMouse(); 
    }

    void MovieWithTarget() {
        targetPos = transform.position + offsetPos;
        transform.position = targetPos;
    }

    void RotateTowardsMouse() {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //player.eulerAngles = new Vector3(0f, Mathf.Round(yaw), 0f);
    }


    


        


}

