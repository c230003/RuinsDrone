using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTargetScipt : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] CameraScript cameraScript;
    void Start()
    {
        
    }

    void Update()
    {
        if(cameraScript.action == false)
        {
            transform.position = target.transform.position;
        }
    }
}
