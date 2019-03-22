using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 LVposition, newLVPosition; // Positions between which the Lead Vehicle oscillates
    private GameObject LV; // LV object
    private float increaseZPosition; // Range of increase in distance of LV from player
    private int probLV; // Probability to randomize LV approach - **unused**
    public float smoothTime = 0.3F;
    private float velocity = 1.0f;
    public float eccentricity = 1.0f; // length from 0 to endpoint.

    private Renderer rend;
    void Awake()
    {
        LV = GameObject.FindGameObjectWithTag("LV"); // Get LV object
        LVposition = LV.transform.position; // Get LV position

    }

    void Start()
    {
        rend = LV.GetComponent<Renderer>();
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
        newLVPosition = new Vector3(LVposition.x, LVposition.y, LVposition.z + Mathf.PingPong(velocity * Time.time, eccentricity)); // Oscillate LV as a function of time
        //Debug.Log(rend);
        LV.transform.position = newLVPosition; // Render LV at new position

    }

    // Unused
    IEnumerator Brake()
    {
        LV.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.1f);
    }
}