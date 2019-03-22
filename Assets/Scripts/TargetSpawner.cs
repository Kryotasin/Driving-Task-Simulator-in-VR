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

        int spawnPointRange = Random.Range(-2, 2);

        //Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        if (spawnPointRange != 0)
        {
            Instantiate(target, HMD.transform.position + new Vector3(spawnPointRange, 0, 0.5f), HMD.transform.rotation);

            targetActive = true;
        }
    }
}
