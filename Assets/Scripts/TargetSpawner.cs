using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target; // Target Object
    //public Transform[] spawnPoints;
    public bool targetActive = false; // Flag to check if the target is in the scene

    public GameObject HMD; // VR Camera Object - center

    public int spawnRange; // Range for target to spawn in - **unused**
    public bool inStartArea = false; // Flag to see if the controller is in the start area

    public int targetNumber = 1; // Keep count of the target

    public Vector3 spawnPosition; // Position of the spawned target

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (!targetActive && inStartArea)
        {
            InstantiateTarget();
        }
    }


    void InstantiateTarget()
    {

        int spawnPointRange = Random.Range(-1, 2); // Generate random number between the range

        //Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        if (spawnPointRange != 0) // Excluding spawns for 0 offset
        {
            spawnPosition = HMD.transform.position + new Vector3(spawnPointRange, 0, 0.5f); // Set the position of the target
            Instantiate(target, spawnPosition, HMD.transform.rotation); // Instantiate the target

            targetActive = true; // Set the flag to indicate the target is in scene

            targetNumber = targetNumber + 1; // Increase the target count by 1
        }
    }
}
