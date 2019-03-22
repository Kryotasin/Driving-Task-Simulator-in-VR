using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    //public Transform[] spawnPoints;
    public bool targetActive = false;

    public GameObject HMD;

    public int spawnRange;
    public bool inStartArea = false;

    public int targetNumber = 0;

    public Vector3 spawnPosition;

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

        int spawnPointRange = Random.Range(-1, 2);

        //Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        if (spawnPointRange != 0)
        {
            spawnPosition = HMD.transform.position + new Vector3(spawnPointRange, 0, 0.5f);
            Instantiate(target, spawnPosition, HMD.transform.rotation);

            targetActive = true;
        }
        targetNumber = targetNumber + 1;
    }
}
