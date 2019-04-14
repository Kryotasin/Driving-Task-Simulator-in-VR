using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCollisionDetector : MonoBehaviour
{

    private float initTime; // Time the target is intialized in the scene
    private float endTime; // Time the target is hit with the controller

    public GameObject targetSpawnController; // GameObject that holds the TargetSpawn script
    private TargetSpawner targetSpawnnerScript; // The target spawn script

    private List<GameObject> spawnList = new List<GameObject>(); // List to maintain the 40 spawn points, 10 each 
    public GameObject HMD; // the VR Camera - center eye
    public GameObject startArea; // The start area sphere
    public GameObject[] spawnPoints; //The spawn points to spawn targets at

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
        //  Generate the list for 10 targets at each points
        for(int i=0; i<spawnPoints.Length; i++){
            for(int j=0;j<10;j++){
            spawnList.Add(spawnPoints[i]);
            }
        }
        
        // Call the shuffle function 3 times to have good randomization
        Shuffle();
        Shuffle();
        Shuffle();
        // Test print of list
        //  foreach(GameObject k in spawnList){
        //     Debug.Log("Initial: " + k);
        // }
    }

    /*
        This function shuffles the list of spawnPoints
    */
    void Shuffle(){
        int len = spawnList.Count; // get the length of spawnlist
        GameObject temp;
        // Till the length of list, shuffle random index with 
        // another random index
        while(len > 1){
            int source = Random.Range(0, len);
            int destination = Random.Range(0, len);
            if(source == destination){
                destination = Random.Range(0, len);
            }

            temp = spawnList[source];
            spawnList[source] = spawnList[destination];
            spawnList[destination] = temp;
            len --;
        }
        Debug.Log("Shuffled: " + spawnList[15]);
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
