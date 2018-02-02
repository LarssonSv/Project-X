using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward/10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back/10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down*2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up*2);
        }
    }
}
