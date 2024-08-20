using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] float droneSpeedZ;
    [SerializeField] float droneSpeedY;
    [SerializeField] Rigidbody droneRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float droneRotX = Input.GetAxisRaw("Horizontal");
        if (droneRotX != 0) //ç∂âEâÒì]
        {
            transform.Rotate(new Vector3(0, droneRotX, 0));
        }

        float posX = Input.GetAxisRaw("Vertical");
        if (posX != 0) //ëOå„à⁄ìÆ
        {
            droneRB.AddForce(transform.forward * droneSpeedZ);
            droneSpeedZ += posX * 0.01f;
        }
    }
}
