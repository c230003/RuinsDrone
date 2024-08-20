using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCheckPointScript : MonoBehaviour
{
    GameObject nextCheckPoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void NextOn()
    {
        nextCheckPoint.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "CheckPoint") 
        {
            nextCheckPoint = other.gameObject;
        }
    }
}
