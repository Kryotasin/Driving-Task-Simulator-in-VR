using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
     public GameObject target;
    public Transform[] spawnPoints;
    public bool targetActive = false;
  void Update()
    {
        if (!targetActive)
        {
            InstantiateTarget();
        }
    }


    void InstantiateTarget()
    {

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        targetActive = true;

        Debug.Log("Object Instantiated");
    }
}
