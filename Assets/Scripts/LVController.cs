using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 LVposition, newLVPosition;
    private GameObject LV;
    private float increaseZPosition;
    public float smoothTime = 0.3F;
    private float velocity = 1.0f;
    public float eccentricity= 1.0f; // length from 0 to endpoint.
    void Awake()
    {
        LV = GameObject.FindGameObjectWithTag("LV");
        LVposition = LV.transform.position;

 }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Here will be the check to see if 200 objects have ben populated. If yes,
        // Then the eccentricity will change aand so on.
    
        newLVPosition = new Vector3 (LVposition.x, LVposition.y, LVposition.z + Mathf.PingPong (velocity * Time.time, eccentricity));
        LV.transform.position = newLVPosition;

    }
}
