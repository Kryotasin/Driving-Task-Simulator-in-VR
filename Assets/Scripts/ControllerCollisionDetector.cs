using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollisionDetector : MonoBehaviour
{

    private float initTime; // Time the target is intialized in the scene
    private float endTime; // Time the target is hit with the controller

    public GameObject targetSpawnController; // GameObject that holds the TargetSpawn script
    private TargetSpawner targetSpawnnerScript; // The target spawn script
    private int indexHolder;

    public GameObject objectiveObject;

    private ObjectiveController objectiveController;
   
    public bool activateTask = false;
    /*
        In this function we get the TargSpawn script object and set the position of the start area relative to the position of the 
        head/camera in the Unity scene
     */
    void Awake()
    {
        targetSpawnnerScript = targetSpawnController.GetComponent<TargetSpawner>();
     
    }

    void Start()
    {
        objectiveController = objectiveObject.GetComponent<ObjectiveController>();
        indexHolder = targetSpawnnerScript.targetNumber;
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
            // endTime = Time.time;
            // Debug.Log("End Time: " + endTime);

            // Debug.Log("Time Taken: " + (endTime - initTime));

            // Unset the flags to indicate the target is now inactive and that the controller is not in the start area
            targetSpawnnerScript.targetActive = false;
            targetSpawnnerScript.inStartArea = false;

            // Activate the start area
            // startArea.SetActive(true);

            // targetSpawnnerScript.targetNumber = -1; // Increase the target count by 1

        }

        // Enter this is the Object collided with is the start area
        if (other.gameObject.CompareTag("StartArea"))
        {
            Debug.Log("Collision Start Area");




            // other.gameObject.SetActive(false); // Deactivate the start area
            // targetSpawnnerScript.inStartArea = true; // Set the flag to indicate the controllre is now in the start area
            // initTime = Time.time; // set the start time


            //Debug.Log("Init Time: " + initTime);
            // targetSpawnnerScript.targetNumber = indexHolder + 1; // Increase the target count by 1
            // indexHolder ++;
        }
    }
}
