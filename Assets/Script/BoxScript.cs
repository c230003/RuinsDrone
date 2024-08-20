using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] int boxNum;
    [SerializeField] PlayerScript playerScript;
    [SerializeField] CameraScript cameraScript;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip woodAS;
    [SerializeField] AudioClip glassAS;
    [SerializeField] AudioClip canAS;
    [SerializeField] AudioClip CheckPointAS;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "BreakOBJ" && cameraScript.action)
        {
            Destroy(other.gameObject);
        }
        else
        {
            if (boxNum == 1)
            {
                playerScript.Box1();
            }
            if (boxNum == 2)
            {
                playerScript.Box2();
            }
            if (boxNum == 3)
            {
                playerScript.Box3();
            }
            if (boxNum == 4)
            {
                playerScript.Box4();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wood")
        {
            audioSource.PlayOneShot(woodAS);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Glass")
        {
            audioSource.PlayOneShot(glassAS);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Can")
        {
            audioSource.PlayOneShot(canAS);
        }

        if(other.gameObject.tag == "CheckPoint")
        {
            audioSource.PlayOneShot(CheckPointAS);
        }

        if(other.gameObject.tag == "Area")
        {
            return;
        }

        if (other.gameObject.tag != "Action")
        {
            if (boxNum == 1)
            {
                playerScript.Box1();
            }
            if (boxNum == 2)
            {
                playerScript.Box2();
            }
            if (boxNum == 3)
            {
                playerScript.Box3();
            }
            if (boxNum == 4)
            {
                playerScript.Box4();
            }
        }   
    }
}
