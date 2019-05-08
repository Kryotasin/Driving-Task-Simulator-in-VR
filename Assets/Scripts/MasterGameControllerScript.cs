using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterGameControllerScript : MonoBehaviour
{
    public GameObject objectiveObject,notificationObject, objectTrackingLogger;
    public GameObject startArea;

    private NotificationController notificationController;
    
    private ObjectiveController objectiveController;

    private StartAreaController startAreaController;

    public float startTime = 0;
    public float uiComponentInteractionTime = 0;
    public float uiComponentExitTime = 0;
    public float hornTime = 0;
    
    public List<int> taskList = new List<int>();

    public bool taskOnGoing = false, taskEnded = false;

    private int taskIndex;

    private HandTracker handTracker;

    void Start()
    {
        // Get all variables
        notificationController = notificationObject.GetComponent<NotificationController>();
        startAreaController = startArea.GetComponent<StartAreaController>();
        objectiveController = objectiveObject.GetComponent<ObjectiveController>();
        handTracker = objectTrackingLogger.GetComponent<HandTracker>();

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


        InvokeRepeating("periodicInvoker", 3.0f, 5.0f);
    }

    void periodicInvoker(){
            StartCoroutine(taskStarter());
    }

    IEnumerator taskStarter(){  
        yield return new WaitForSeconds(3);

        taskOnGoing = true;
        Debug.Log("Running new task" + taskOnGoing);

            switch(taskList[taskIndex]){
                /*
                1 - Play and Pause
                2 - Previous
                3 - Next
                4 - Yes
                5 - No
                */

                case 1:
                    objectiveController.SetText("Play/Pause the music.");
                    objectiveObject.SetActive(true);
                    break;

                case 2:
                    objectiveController.SetText("Go to Previous Track.");
                    objectiveObject.SetActive(true);
                    break;

                case 3:
                    objectiveController.SetText("Go to Next Track.");
                    objectiveObject.SetActive(true);
                    break;

                case 4:
                    notificationController.SetText("Press 'Yes' if you are awake.");
                    notificationObject.SetActive(true);
                    break;

                case 5:
                    notificationController.SetText("Press 'No' if you are not sleeping.");
                    notificationObject.SetActive(true);
                    break;

            }
            taskIndex++;
            
            if(taskIndex == 41){
                objectiveController.SetText("Session Complete");
                objectiveObject.SetActive(true);
            }
    }

    void Update(){
        if(taskOnGoing){
            
        }
    }

    public void endTask(){
        taskOnGoing = false;

        handTracker.taskNumber = taskList[taskIndex];

        handTracker.startTime = startTime;

        handTracker.uiComponentInteractionTime = uiComponentInteractionTime;

        handTracker.uiComponentExitTime = uiComponentExitTime;

        handTracker.hornTime = hornTime;


        handTracker.WriteFile();

        Debug.Log(startTime + " " +  uiComponentInteractionTime + " " +  uiComponentExitTime + " " + hornTime);

        startTime = 0;
        uiComponentInteractionTime = 0;
        uiComponentExitTime = 0;
        hornTime = 0;
    }

   
}
