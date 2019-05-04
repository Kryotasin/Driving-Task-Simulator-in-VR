using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameControllerScript : MonoBehaviour
{
    public GameObject objectiveObject;

    private ObjectiveController objectiveController;

    public float startTime = 0;
    public float uiComponentInteraction = 0;
    public float hornTime = 0;
    void Start()
    {
        objectiveController = objectiveObject.GetComponent<ObjectiveController>();
        InvokeRepeating("randomizedStartTask", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomizedStartTask(){
            float randTime = Random.value * 10 / 2;
            Invoke("taskStarter", randTime);
    }

    void taskStarter(){
        objectiveController.activateObjectiveTask = true;
    }
}
