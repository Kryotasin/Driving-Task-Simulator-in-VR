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

    public int[] taskList;
    void Start()
    {
        objectiveText = objective.GetComponent<TextMeshPro>();

        int j = 1;

        for(int i = 0; i < 40; i++){
            if(j == 5){
                j = 0;
                taskList[i] = j++;
            }
        }

        for(int i = 0; i < 40; i++){
            Debug.Log(taskList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int caseIndex = Random.Range(1, 5);

        if(activateObjectiveTask){
            objectiveText.text = "Grip the start area to start.";
            objective.SetActive(true);
        }
    }
}
