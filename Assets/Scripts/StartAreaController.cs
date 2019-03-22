using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAreaController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject HMD;

    void Start()
    {
        transform.position = HMD.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cool Down Area");
        }
    }
}
