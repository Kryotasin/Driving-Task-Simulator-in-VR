using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target; // Target Object
    //public Transform[] spawnPoints;
    public bool targetActive = false; // Flag to check if the target is in the scene

    public GameObject HMD; // VR Camera Object - center

    public int spawnRange; // Range for target to spawn in - **unused**

    private List<GameObject> spawnList = new List<GameObject>(); // List to maintain the 40 spawn points, 10 each 

    private int index = 0; // index to keep track of spawnpoints in Update()
    public bool inStartArea = false; // Flag to see if the controller is in the start area

    public int targetNumber = 1; // Keep count of the target

    public Vector3 spawnPosition; // Position of the spawned target
    public GameObject[] spawnPoints; //The spawn points to spawn targets at


    void Awake()
    {

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
         foreach(GameObject k in spawnList){
            Debug.Log("Initial: " + k);
        }
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

    void Update()
    {
        if (!targetActive && inStartArea && (index < spawnList.Count))
        {
            InstantiateTarget(spawnList[index].transform.position);
            index ++;
        }
    }


    void InstantiateTarget(Vector3 spawnPoint)
    {

        //int spawnPointRange = Random.Range(-1, 2); // Generate random number between the range

        //Instantiate(target, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        // if (spawnPointRange != 0) // Excluding spawns for 0 offset
        // {
            // spawnPosition = HMD.transform.position + new Vector3(spawnPointRange, 0, 0.5f); // Set the position of the target

            // Debug.Log(spawnPosition);

            spawnPosition = spawnPoint;

            Instantiate(target, spawnPosition, HMD.transform.rotation); // Instantiate the target

            targetActive = true; // Set the flag to indicate the target is in scene

            targetNumber = targetNumber + 1; // Increase the target count by 1
        // }
    }
}
