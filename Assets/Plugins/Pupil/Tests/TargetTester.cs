using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTester : MonoBehaviour
{

    public PupilLabs.CircleCalibrationTargets targets;
    public Transform target;
    [Range(0,20)]
    public int position;
    
    // Start is called before the first frame update
    
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
        if (position < targets.GetTargetCount())
        {
            // target.localPosition = targets.GetLocalTargetPosAt(position);
            target.position = target.parent.localToWorldMatrix.MultiplyPoint(targets.GetLocalTargetPosAt(position));
        }
    }

    void OnDrawGizmos()
    {
        for (int i=0;i<targets.GetTargetCount();++i)
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = target.parent.localToWorldMatrix;
            Gizmos.DrawSphere(targets.GetLocalTargetPosAt(i),0.05f);
        }
    }
}
