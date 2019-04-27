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

    private Renderer rend;
    void Awake()
    {
        GPSTarget = GameObject.FindGameObjectWithTag("TargetForGPS"); // Get LV object
        Targetposition = GPSTarget.transform.position; // Get LV position

    }

    void Start()
    {
        rend = GPSTarget.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("s"))
        {
            StartCoroutine("Brake"); // May not work
        }
        //Here will be the check to see if 200 objects have ben populated. If yes,
        // Then the eccentricity will change aand so on. - Future

        /*
            Generate a random number between 1 and 5 giving.
         */
        probLV = Random.Range(0, 3); // Unused


        float time = Time.time;
        newTargetPosition = new Vector3(Targetposition.x + Mathf.PingPong(velocity * Time.time, eccentricity), Targetposition.y, Targetposition.z); // Oscillate LV as a function of time
        //Debug.Log(rend);
        GPSTarget.transform.position = newTargetPosition; // Render LV at new position

    }

    // Unused
    IEnumerator Brake()
    {
        GPSTarget.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.1f);
    }
}