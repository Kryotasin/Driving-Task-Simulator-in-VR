using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationController : MonoBehaviour
{

    public GameObject notification;

    public GameObject yesObject;
    public GameObject noObject;
    public GameObject okObject;
    public TextMeshPro notificationText;
    void Start()
    {
        notificationText = notification.GetComponent<TextMeshPro>();

        // notificationText.text = "Press Ok to continue";
        // yesObject.SetActive(false);
        // noObject.SetActive(false);
        // okObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
