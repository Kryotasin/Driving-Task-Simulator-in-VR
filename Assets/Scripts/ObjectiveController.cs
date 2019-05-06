using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveController : MonoBehaviour
{

    public GameObject objective;

    public GameObject okObject;
    public TextMeshPro objectiveText;

    public bool activateObjectiveTask = false;

    public GameObject masterGameControllerObejct;

    private MasterGameControllerScript masterGameControllerScript;

    void Start()
    {
        objectiveText = objective.GetComponent<TextMeshPro>();

        masterGameControllerScript = masterGameControllerObejct.GetComponent<MasterGameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        int caseIndex = Random.Range(1, 5);

        // if(activateObjectiveTask){
        //     objectiveText.text = "Grip the start area to start.";
        //     objective.SetActive(true);
        // }
    }
}
