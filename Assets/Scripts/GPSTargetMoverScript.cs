using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSTargetMoverScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 Targetposition, newTargetPosition; // Positions between which the Lead Vehicle oscillates
    private GameObject GPSTarget; // LV object
    private float increaseZPosition; // Range of increase in distance of LV from player
    private int probLV; // Probability to randomize LV approach - **unused**
    public float smoothTime = 0.3F;
    public float velocity = 1.0f;
    public float eccentricity = 5.0f; // length from 0 to endpoint.
    
    void Awake()
    {
        GPSTarget = GameObject.FindGameObjectWithTag("TargetForGPS"); // Get LV object
        Targetposition = GPSTarget.transform.position; // Get LV position
    }

    void Start()
    {
        // rigidbody = GPSTarget.GetComponent<Rigidbody>();
        InvokeRepeating("mover", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void moveItem(){
        // GPSTarget.transform.position = newTargetPosition; // Render LV at new position
        // newTargetPosition = new Vector3(Targetposition.x + Mathf.PingPong(velocity * Time.time, eccentricity), Targetposition.y, Targetposition.z); // Oscillate LV as a function of time
        GPSTarget.transform.position = new Vector3(Targetposition.x + (velocity * Mathf.PingPong(velocity * Time.time, eccentricity)) ,Targetposition.y, Targetposition.z);
    }

     void FixedUpdate(){
        newTargetPosition = new Vector3(Targetposition.x + Mathf.PingPong(velocity * Time.time, eccentricity), Targetposition.y, Targetposition.z); // Oscillate LV as a function of time
    }

    void mover(){
         if(Random.value > 0.5){
            velocity = 1.0f;
        }else{
            velocity = -1.0f;
        }
        Debug.Log(velocity);
        moveItem();
    }
   
}