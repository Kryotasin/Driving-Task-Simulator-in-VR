using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollisionDetector : MonoBehaviour
{
    private float initTime;
    private float endTime;

    public GameObject targetSpawnController;
    private TargetSpawner targetSpawnnerScript;

    public GameObject HMD;
    public GameObject startArea;
    void Awake()
    {
        targetSpawnnerScript = targetSpawnController.GetComponent<TargetSpawner>();
        startArea.transform.position = HMD.transform.position + new Vector3(0, 0, 1.0f);
    }

    void Start()
    {
        HMD.transform.position = HMD.transform.position + new Vector3(0, 0, 1.0f);
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

            endTime = Time.time;
            Debug.Log("End Time: " + endTime);

            Debug.Log("Time Taken: " + (endTime - initTime));
            targetSpawnnerScript.targetActive = false;
            targetSpawnnerScript.inStartArea = false;

            startArea.SetActive(true);
        }

        if (other.gameObject.CompareTag("StartArea"))
        {
            other.gameObject.SetActive(false);
            targetSpawnnerScript.inStartArea = true;
            initTime = Time.time;
            Debug.Log("Init Time: " + initTime);
        }
    }
}
