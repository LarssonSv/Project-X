using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    
    public Transform target;
    public Vector3 offsetPos;
    public float moveSpeed = 5;

    Vector3 targetPos;
 



	
	void FixedUpdate () {
        MovieWithTarget();
    }

    void MovieWithTarget() {
        targetPos = target.position + offsetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

}

