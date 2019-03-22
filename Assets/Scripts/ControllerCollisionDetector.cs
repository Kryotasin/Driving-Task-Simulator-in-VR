using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollisionDetector : MonoBehaviour
{
    private float initTime;
    private float endTime;

    public GameObject targetSpawnController;
    private TargetSpawner targetSpawnnerScript;
    void Awake(){
        targetSpawnnerScript = targetSpawnController.GetComponent<TargetSpawner>();
        initTime = Time.time;
        Debug.Log(initTime );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Debug.Log("Collision");
            other.gameObject.SetActive(false);
        }
        endTime = Time.time;
        Debug.Log(endTime);

        Debug.Log(endTime - initTime );
        targetSpawnnerScript.targetActive = false;
    }
}
