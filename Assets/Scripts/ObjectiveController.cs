using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveController : MonoBehaviour
{

    public GameObject objective, notificationObject;

    private NotificationController notificationController;

    public GameObject okObject;
    public TextMeshPro objectiveText;

    public bool activateObjectiveTask = false;

    public GameObject masterGameControllerObejct;

    private MasterGameControllerScript masterGameControllerScript;

    void Start()
    {
        objectiveText = objective.GetComponent<TextMeshPro>();
        notificationController = notificationObject.GetComponent<NotificationController>();

        masterGameControllerScript = masterGameControllerObejct.GetComponent<MasterGameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if(activateObjectiveTask){
            objective.SetActive(false);


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
                    objective.SetActive(true);
                    activateObjectiveTask = false;
                break;

                case 2:
                    objectiveText.text = "Go to Previous Track.";
                    objective.SetActive(true);
                    activateObjectiveTask = false;
                break;

                case 3:
                    objectiveText.text = "Go to Next Track.";
                    objective.SetActive(true);
                    activateObjectiveTask = false;
                break;

                case 4:
                    notificationController.notificationText.text = "Press 'Yes' if you are awake.";
                    notificationObject.SetActive(true);
                    activateObjectiveTask = false;
                break;

                case 5:
                    notificationController.notificationText.text = "Press 'No' if you are not sleeping.";
                    notificationObject.SetActive(true);
                    activateObjectiveTask = false;
                break;

            }
            }
       
    }
}
