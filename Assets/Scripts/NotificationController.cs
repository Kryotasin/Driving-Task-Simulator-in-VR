using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationController : MonoBehaviour
{

    public TextMeshPro notificationText;
    void Start()
    {
        notificationText = GetComponent<TextMeshPro>();
    }
    void Update()
    {
        
    }

    public void SetText(string inputText){
        notificationText.text = inputText;
    }
}
