using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [SerializeField] AudioSource CheckPoint;
    [SerializeField] NextCheckPointScript nextCheckPointScript;
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    void Delete()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckPoint.Play();
        nextCheckPointScript.NextOn();
        Invoke("Delete", 0.2f);
    }
}
