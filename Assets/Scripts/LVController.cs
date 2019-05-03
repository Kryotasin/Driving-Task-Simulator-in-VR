using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 LVposition, newLVPosition; // Positions between which the Lead Vehicle oscillates
    private GameObject LV; // LV object
    private float increaseZPosition; // Range of increase in distance of LV from player
    private float probLV; // Probability to randomize LV approach - **unused**
    public float smoothTime = 0.3F;
    private float velocity = 1.0f;
    public float eccentricity = 1.0f; // length from 0 to endpoint.


    public Material redLaneIndicator;
    public Material normalLaneIndicator;
    public GameObject laneIndicator;
    public bool activateLV = false;
    public float minimum = -10.0F;
    public float maximum =  37.0F;

     // starting value for the Lerp
    static float t = 0.0f;
    private Renderer rend;
    void Awake()
    {
        LV = GameObject.FindGameObjectWithTag("LV"); // Get LV object
    }

    void Start()
    {
        rend = LV.GetComponent<Renderer>();
        Invoke("boolChanger", 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    { 

            // animate the position of the game object...
            LV.transform.position = new Vector3(-3, 0, 35 + Mathf.Lerp(minimum, maximum, t));

            // .. and increase the t interpolater
            if(activateLV){
                t += 1.0f * Time.deltaTime;
                laneIndicator.GetComponent<MeshRenderer>().material = redLaneIndicator;
            }
            else{
                t += 0.1f * Time.deltaTime;
                laneIndicator.GetComponent<MeshRenderer>().material = normalLaneIndicator;
            }
            

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.0f;
            }
        }


        void boolChanger(){
            activateLV = !activateLV;
        }
 }

