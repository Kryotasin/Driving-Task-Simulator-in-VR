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
    void Start()
    {
        objectiveText = objective.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activateObjectiveTask){

        }
    }
}
