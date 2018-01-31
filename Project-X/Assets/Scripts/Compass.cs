using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    public Vector3 northDirection;
    public Transform player;
    public Quaternion MissionDirection;


    public RectTransform northLayer;
    public RectTransform MissionLayer;

    public Transform missionplace;


    void Update () {
        ChangeNorthDirection();
        ChangeMissionDirection();

    }

    void ChangeNorthDirection() {
        northDirection.z = player.eulerAngles.z;
        northLayer.localEulerAngles = northDirection;
    }
    
    void ChangeMissionDirection() {
        Vector3 dir = transform.position - missionplace.position;
        MissionDirection = Quaternion.LookRotation(dir);

        MissionDirection.z = -MissionDirection.y;
        MissionDirection.x = 0;
        MissionDirection.y = 0;

        MissionLayer.localRotation = MissionDirection * Quaternion.Euler(northDirection);
    }



}
