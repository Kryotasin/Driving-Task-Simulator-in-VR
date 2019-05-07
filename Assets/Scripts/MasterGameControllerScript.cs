using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterGameControllerScript : MonoBehaviour
{
    public GameObject objectiveObject,notificationObject;
    public GameObject startArea;

    private ObjectiveController objectiveController;
    private NotificationController notificationController;
    

    private StartAreaController startAreaController;

    public float startTime = 0;
    public float uiComponentInteraction = 0;
    public float hornTime = 0;
    
    public List<int> taskList = new List<int>();

    public bool taskOnGoing = false;

    public TextMeshPro objectiveText;

    void Start()
    {
        notificationController = notificationObject.GetComponent<NotificationController>();
        objectiveController = objectiveObject.GetComponent<ObjectiveController>();
        startAreaController = startArea.GetComponent<StartAreaController>();
        objectiveText = objectiveObject.GetComponent<TextMeshPro>();

        
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
        Debug.Log("Running new task" + taskOnGoing);


        objectiveObject.SetActive(false);


            int caseIndex = Random.Range(1, 3);

            switch(caseIndex){
                /*
                1 - Play and Pause
                2 - Previous
                3 - Next
                4 - Yes
                5 - No
                */

                case 1:
                    objectiveText.text = "Play/Pause the music.";
                    objectiveObject.SetActive(true);
                break;

                case 2:
                    objectiveText.text = "Go to Previous Track.";
                    objectiveObject.SetActive(true);
                break;

                case 3:
                    objectiveText.text = "Go to Next Track.";
                    objectiveObject.SetActive(true);
                break;

                case 4:
                    notificationController.notificationText.text = "Press 'Yes' if you are awake.";
                    notificationObject.SetActive(true);
                break;

                case 5:
                    notificationController.notificationText.text = "Press 'No' if you are not sleeping.";
                    notificationObject.SetActive(true);
                break;

            }
    }

    void endTask(){
        objectiveController.activateObjectiveTask = false;
        startAreaController.isTaskActive = false;
        taskOnGoing = false;
    }

   
}
