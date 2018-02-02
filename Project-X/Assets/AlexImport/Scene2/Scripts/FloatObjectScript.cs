using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatObjectScript : MonoBehaviour {

    [SerializeField]
    private float waterLevel = 0.0f,
    floatTreshold = 2.0f,
    waterDensity = 0.125f,
    downForce = 4.0f;
    private float forceFactor;

    Vector3 floatForce;	
	
	void FixedUpdate () {
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatTreshold);

        if (forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce * GetComponent<Rigidbody>().mass, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
	}
}
