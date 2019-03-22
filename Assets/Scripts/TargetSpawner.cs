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
    void Start()
    {

    }

    void Update()
    {
        if (!targetActive)
        { 
            InstantiateTarget();
        }
    }


    void InstantiateTarget()
    {

        int spawnPointRange = Random.Range(-2, 2);

        //Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        if(spawnPointRange != 0){
        Instantiate(target, HMD.transform.position + new Vector3(spawnPointRange, 0, 0), HMD.transform.rotation);

        targetActive = true;

        Debug.Log("Object Instantiated");
        }
    }
}
