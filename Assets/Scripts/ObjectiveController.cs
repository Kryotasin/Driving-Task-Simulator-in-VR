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

    // Update is called once per frame
    void Update()
    {
    }
}
