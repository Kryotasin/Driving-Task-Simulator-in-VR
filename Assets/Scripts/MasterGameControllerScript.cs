using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameControllerScript : MonoBehaviour
{
    public GameObject objectiveObject;

    private ObjectiveController objectiveController;
    
    public GameObject startArea;

    private StartAreaController startAreaController;

    public float startTime = 0;
    public float uiComponentInteraction = 0;
    public float hornTime = 0;
    
    public List<int> taskList = new List<int>();

    public bool taskOnGoing = false;

    void Start()
    {

        objectiveController = objectiveObject.GetComponent<ObjectiveController>();
        startAreaController = startArea.GetComponent<StartAreaController>();
        InvokeRepeating("randomizedStartTask", 1f, 1f);

        
        int j = 1;

        // Create the Task List
        for(int i=1;i<=50;i++){
            taskList.Add(j);
            if(i % 10 == 0){
                j++;
            }
        }

        // Shuffle the Task List
        for (int i = 0; i < taskList.Count; i++) {
         int temp = taskList[i];
         int randomIndex = Random.Range(i, taskList.Count);
         taskList[i] = taskList[randomIndex];
         taskList[randomIndex] = temp;
     }

        foreach(int k in taskList){
            Debug.Log(k);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomizedStartTask(){
            float randTime = Random.Range(6, 12);

            if(!taskOnGoing){
                Invoke("taskStarter", randTime);
            }
    }

    void taskStarter(){
        objectiveController.activateObjectiveTask = true;
        startAreaController.isTaskActive = true;
        taskOnGoing = true;
    }

    void endTask(){
        objectiveController.activateObjectiveTask = false;
        startAreaController.isTaskActive = false;
        taskOnGoing = false;
    }

   
}
