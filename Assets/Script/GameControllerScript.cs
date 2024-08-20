using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public float resultTime;
    float timer;

    bool timeAtack;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (timeAtack)
        {
            TimerOn();
        }
    }

    public void TAstart()
    {
        timer = 0;
        timeAtack = true;
    }

    public void TAend() 
    {
        resultTime = timer;
    }

    void TimerOn()
    {
        timer = Time.deltaTime;
    }
}
