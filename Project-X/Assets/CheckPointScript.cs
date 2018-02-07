using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    [SerializeField]
    private GameObject playerBoat, startLocation;

    private GameObject spawnPoint;

    private void Start()
    {
        spawnPoint = startLocation;        
    }

    public void NewSpawnPoint(GameObject newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    public void OnCharacterDeath()
    {
        Instantiate(playerBoat, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

}
