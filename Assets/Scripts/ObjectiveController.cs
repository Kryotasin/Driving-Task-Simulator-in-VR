using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveController : MonoBehaviour
{

    public GameObject objective;

    public GameObject okObject;
    private TextMeshPro notificationText;
    void Start()
    {
        notificationText = objective.GetComponent<TextMeshPro>();

        notificationText.text = "Press Ok to continue";
    }

    // Update is called once per frame
    void Update()
    {
        


        // switch(){
        //     case 0:
        //     break;

        // }

    }
}
