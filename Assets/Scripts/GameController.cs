using UnityEngine;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
    public GameObject target;
    public Transform[] spawnPoints;
    public bool targetActive = false;

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

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        targetActive = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(target);
            Debug.Log("Collision");
        }
    }
}