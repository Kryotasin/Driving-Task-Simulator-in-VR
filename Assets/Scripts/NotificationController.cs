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
    private TextMeshPro notificationText;
    void Start()
    {
        notificationText = notification.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        notificationText.text = "Press Ok to continue";
    }
}
