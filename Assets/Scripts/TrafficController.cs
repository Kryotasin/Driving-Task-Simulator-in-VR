using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{

    public GameObject vehicle, spawnSameDir, spawnOppositeDir, car;
        void Start()
    {
        InvokeRepeating("trafficInvoker", 3.0f, 5.0f);
    }

    void trafficInvoker(){
            StartCoroutine(traffic());
    }

    // Update is called once per frame
    IEnumerator traffic()
    {
        yield return new WaitForSeconds(2);
        int trafficSide = Random.Range(1,3);

        switch(trafficSide){
            case 1:
            car = Instantiate(vehicle, spawnSameDir.transform.position, spawnSameDir.transform.rotation);
            
            for(int i = 0; i<180; i++){
                car.transform.position = new Vector3(spawnSameDir.transform.position.x, spawnSameDir.transform.position.y, spawnSameDir.transform.position.y - i); 
            }
            Destroy(car.gameObject);
            break;
            case 2:
            car = Instantiate(vehicle, spawnOppositeDir.transform.position, spawnOppositeDir.transform.rotation);
            
            for(int i = 0; i<250; i++){
                car.transform.position = new Vector3(spawnOppositeDir.transform.position.x, spawnOppositeDir.transform.position.y, spawnOppositeDir.transform.position.y + i); 
            }
            Destroy(car.gameObject);
            break;
        }
        
    }
}
