using UnityEngine;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
    public GameObject target;
    public Transform[] spawnPoints;

    void Start()
    {
        InvokeRepeating("InstantiateTarget", 2.0f, 0.3f);
    }

    void InstantiateTarget()
    {
        
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    
    }
}