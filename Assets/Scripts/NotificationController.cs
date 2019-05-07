using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationController : MonoBehaviour
{

    public GameObject notification;
    public TextMeshPro notificationText;
    void Start()
    {
        notificationText = notification.GetComponent<TextMeshPro>();
    }
    void Update()
    {
        
    }
}
