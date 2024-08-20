using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    [SerializeField] float droneSpeedZ;
    [SerializeField] float droneSpeedY;
    [SerializeField] Rigidbody droneRB;

    float timerQ = 1.0f;
    float timerE = 1.0f;

    bool Reset = false;
    void Start()
    {
        droneRB.useGravity = true;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {

        if (Input.GetKey(KeyCode.I)) //上昇
        {
            droneRB.useGravity = false;
            droneSpeedY += 0.1f;
            droneRB.velocity = transform.up * droneSpeedY;
        }
        else
        {
            droneRB.velocity = Vector3.up * 0;
        }
        if (Input.GetKey(KeyCode.K)) //下降
        {
            droneRB.useGravity = true;
        }
        if (Input.GetKey(KeyCode.J)) //左移動
        {
            transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.L)) //右移動
        {
            transform.Translate(Vector3.right * 0.1f);
        }
        

        float droneRotX = Input.GetAxisRaw("Horizontal");
        if (droneRotX != 0) //左右回転
        { 
            transform.Rotate(new Vector3(0, droneRotX, 0));
        }

        float posX = Input.GetAxisRaw("Vertical");
        droneRB.velocity = transform.forward * droneSpeedZ;
        if (posX != 0) //前後移動
        {
            droneSpeedZ += posX;
        }

        if (Input.GetKey(KeyCode.Q)) //左アクション
        {
            timerQ = 0;
        }
        if (timerQ < 1)
        {
            timerQ += Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, 305 * Time.deltaTime));
            Reset = true;
        }
        else if (timerE > 1 && Reset)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            Debug.Log("Reset");
            Reset = false;
        }

        if (Input.GetKey(KeyCode.E)) //右アクション
        {
            timerE = 0;
        }
        if (timerE < 1)
        {
            timerE += Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, -305 * Time.deltaTime));
            Reset = true;
        }
        else if (timerQ > 1 && Reset)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            Debug.Log("Reset");
            Reset = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        droneRB.useGravity = true;
    }
}
