using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveController : MonoBehaviour
{
    public TextMeshPro objectiveText;
    void Start()
    {
        objectiveText = GetComponent<TextMeshPro>();

    }

    public void SetText(string inputText){
        objectiveText.text = inputText;
    }
}
