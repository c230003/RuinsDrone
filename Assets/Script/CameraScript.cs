using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject lookTarget;
    [SerializeField] GameObject actTarget;
    [SerializeField] GameObject droneTarget;
    [SerializeField] GameObject nomalTarget;
    public bool action;
    void Start()
    {
        action = false;
    }

    void Update()
    {
        if (action)
        {
            Action();
        }
        else
        {
            Nomal();
        }
    }

    void Action()
    {
        transform.position = actTarget.transform.position;
        transform.LookAt(droneTarget.transform.position);
    }

    void Nomal()
    {
        transform.LookAt(lookTarget.transform.position);
        transform.position =  nomalTarget.transform.position;
    }
}
