using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollisionDetector : MonoBehaviour
{

    private float initTime; // Time the target is intialized in the scene
    private float endTime; // Time the target is hit with the controller

    public GameObject targetSpawnController; // GameObject that holds the TargetSpawn script
    private TargetSpawner targetSpawnnerScript; // The target spawn script

    public GameObject HMD; // the VR Camera - center eye
    public GameObject startArea; // The start area sphere
   
    /*
        In this function we get the TargSpawn script object and set the position of the start area relative to the position of the 
        head/camera in the Unity scene
     */
    void Awake()
    {
        targetSpawnnerScript = targetSpawnController.GetComponent<TargetSpawner>();
        startArea.transform.position = new Vector3(7.0f, 10.0f, -6.2f);
        // Debug.Log(startArea.transform.position);
    }

    void Start()
    {
    }

  

    // Update is called once per frame
    void Update()
    {

    }

    /*
        When the controller collides with any object
        Possible Objects:
        1. Target
        2. Start Area
     */
    private void OnTriggerEnter(Collider other)
    {
        //  Check if the object collided with is the Target

        if (other.gameObject.CompareTag("Target"))
        {
             Debug.Log("Collision");

            // Set the Target as inactive
            other.gameObject.SetActive(false);

            // Set the end time
            endTime = Time.time;
            // Debug.Log("End Time: " + endTime);

            // Debug.Log("Time Taken: " + (endTime - initTime));

            // Unset the flags to indicate the target is now inactive and that the controller is not in the start area
            targetSpawnnerScript.targetActive = false;
            targetSpawnnerScript.inStartArea = false;

            // Activate the start area
            startArea.SetActive(true);
        }

        // Enter this is the Object collided with is the start area
        if (other.gameObject.CompareTag("StartArea"))
        {
            Debug.Log("Collision Start Area");
            other.gameObject.SetActive(false); // Deactivate the start area
            targetSpawnnerScript.inStartArea = true; // Set the flag to indicate the controllre is now in the start area
            initTime = Time.time; // set the start time
            //Debug.Log("Init Time: " + initTime);
        }
    }
}
