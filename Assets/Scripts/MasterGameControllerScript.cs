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
    void Start()
    {
        objectiveController = objectiveObject.GetComponent<ObjectiveController>();
        startAreaController = startArea.GetComponent<StartAreaController>();
        InvokeRepeating("randomizedStartTask", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomizedStartTask(){
            float randTime = Random.value * 10;
            Invoke("taskStarter", randTime);
    }

    void taskStarter(){
        // objectiveController.activateObjectiveTask = true;
        // startAreaController.isTaskActive = true;
    }
}
