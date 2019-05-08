using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationController : MonoBehaviour
{

    public GameObject notificationTextObject;
    public TextMeshPro notificationText;
    void Start()
    {
        notificationText = notificationTextObject.GetComponent<TextMeshPro>();
    }

    public void SetText(string inputText){
        notificationText.text = inputText;
    }
}
