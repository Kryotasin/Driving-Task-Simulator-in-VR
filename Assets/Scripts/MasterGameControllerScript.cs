﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterGameControllerScript : MonoBehaviour
{
    public GameObject instantiatedObject, objectiveObject,notificationObject, spawnObjective, spawnNotification;
    public GameObject startArea;

    private NotificationController notificationController;
    
    private ObjectiveController objectiveController;

    private StartAreaController startAreaController;

    public float startTime = 0;
    public float uiComponentInteractionTime = 0;
    public float hornTime = 0;
    
    public List<int> taskList = new List<int>();

    public bool taskOnGoing = false;

    private int taskIndex;

    void Start()
    {
        // Get all variables
        notificationController = notificationObject.GetComponent<NotificationController>();
        startAreaController = startArea.GetComponent<StartAreaController>();

        taskIndex = 0;
        
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

        InvokeRepeating("periodicInvoker", 3.0f, 15.0f);
    }

    void periodicInvoker(){
            StartCoroutine(taskStarter());
    }

    IEnumerator taskStarter(){
        yield return new WaitForSeconds(5);

        startAreaController.isTaskActive = true;
        taskOnGoing = true;
        Debug.Log("Running new task" + taskOnGoing);
int test = 4;
            // switch(taskList[taskIndex]){
                switch(test){
                /*
                1 - Play and Pause
                2 - Previous
                3 - Next
                4 - Yes
                5 - No
                */

                case 1:
                    instantiatedObject = Instantiate(objectiveObject, spawnObjective.transform.position, spawnObjective.transform.rotation);  
                    objectiveController = instantiatedObject.GetComponent<ObjectiveController>();
                    objectiveController.objectiveText.text = "Play/Pause the music.";
                    break;

                case 2:
                    instantiatedObject = Instantiate(objectiveObject, spawnObjective.transform.position, spawnObjective.transform.rotation);
                    objectiveController = instantiatedObject.GetComponent<ObjectiveController>();
                    objectiveController.objectiveText.text = "Go to Previous Track.";
                    break;

                case 3:
                    instantiatedObject = Instantiate(objectiveObject, spawnObjective.transform.position, spawnObjective.transform.rotation);
                    objectiveController = instantiatedObject.GetComponent<ObjectiveController>();
                    objectiveController.objectiveText.text = "Go to Next Track.";
                    break;

                case 4:
                    instantiatedObject = (GameObject) Instantiate(notificationObject, spawnNotification.transform.position, spawnNotification.transform.rotation);
                    notificationController = instantiatedObject.GetComponent<NotificationController>();
                    notificationController.SetText("Press 'Yes' if you are awake.");
                    break;

                case 5:
                    instantiatedObject = Instantiate(notificationObject, spawnNotification.transform.position, spawnNotification.transform.rotation);
                    notificationController = instantiatedObject.GetComponent<NotificationController>();
                    notificationController.SetText("Press 'No' if you are not sleeping.");
                    break;

            }
            taskIndex++;
            
    }

    void Update(){
    }

    void endTask(){
        startAreaController.isTaskActive = false;
        taskOnGoing = false;
    }

   
}
