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
    }
}
