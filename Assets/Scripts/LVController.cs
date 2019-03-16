using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVController : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 LVposition, newLVPosition;
    private GameObject LV;
    private float increaseZPosition;
    private int probLV;
    public float smoothTime = 0.3F;
    private float velocity = 1.0f;
    public float eccentricity = 1.0f; // length from 0 to endpoint.

    private Renderer rend;
    void Awake()
    {
        LV = GameObject.FindGameObjectWithTag("LV");
        LVposition = LV.transform.position;

    }

    void Start()
    {
        rend = LV.GetComponent<Renderer> ();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("s"))
        {
            StartCoroutine("Brake");
        }
        //Here will be the check to see if 200 objects have ben populated. If yes,
        // Then the eccentricity will change aand so on.

        /*
            Generate a random number between 1 and 5 giving.
         */
        probLV = Random.Range(0, 3);


        float time = Time.time;
        newLVPosition = new Vector3(LVposition.x, LVposition.y, LVposition.z + Mathf.PingPong(velocity * Time.time, eccentricity));
        Debug.Log(rend);
        LV.transform.position = newLVPosition;

    }


    IEnumerator Brake()
    {
      LV.GetComponent<Renderer>().material.color = Color.red;
      yield return new WaitForSeconds(.1f);
    }
}