using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float gravity;
    [SerializeField] float speedZ;
    [SerializeField] float speedJump;
    [SerializeField] float speedRot;
    [SerializeField] float knockBackPow;
    [SerializeField] float actSpeed;

    [SerializeField] CharacterController characterController;

    [SerializeField] CameraScript cameraScript;
    [SerializeField] GameControllerScript gameControllerScript;

    [SerializeField] GameObject droneOBJ;
    [SerializeField] GameObject actionOBJ;
    [SerializeField] GameObject action2OBJ;
    [SerializeField] GameObject target;
    [SerializeField] GameObject targetActOBJ;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject rayStartPos;

    Vector3 moveDirection = Vector3.zero;
    //Vector3 shotVec = Vector3.zero;

    bool knockBack;

    float nowRotX;
    float nowRotY;
    float nowRotZ;

    int pauseState;
    void Start()
    {
        pauseState = 1;
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseState = 1 - pauseState;
            Pause();
        }
    }

    void Move()
    {
        actionOBJ.transform.rotation = Quaternion.Euler(nowRotX, nowRotY, nowRotZ);
        if (knockBack == false && cameraScript.action == false)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            if (Input.GetKey(KeyCode.I) && characterController.height < 1000)
            {
                transform.position += new Vector3(0, 0.1f, 0);
                characterController.height += 5;
                characterController.center -= (Vector3.up * 2.5f);
            }

            if (Input.GetKey(KeyCode.K) && characterController.height > 30)
            {
                characterController.height -= 5;
                characterController.center += (Vector3.up * 2.5f);
            }

            if (Input.GetAxis("Vertical") != 0.0f)
            {
                moveDirection.z = Input.GetAxis("Vertical") * speedZ;
            }

            else
            {
                moveDirection.z = 0.0f;
            }

            transform.Rotate(0, Input.GetAxis("Horizontal") * speedRot, 0);

            nowRotX = transform.rotation.eulerAngles.x;
            nowRotY = transform.rotation.eulerAngles.y;
            nowRotZ = transform.rotation.eulerAngles.z;
        }
        if (Input.GetButtonDown("Jump") && cameraScript.action == false)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 14, Color.red, 0.1f);

            if (Physics.Raycast(rayStartPos.transform.position, rayStartPos.transform.position - transform.position, out hit, 14.0f))
            {
                if (hit.collider.tag == "BreakOBJ")
                {
                    actionOBJ.transform.position = targetActOBJ.transform.position;
                    Debug.Log("BreakHit");
                }
                else
                {
                    actionOBJ.transform.position = hit.point;
                    Debug.Log("hit");
                    Debug.Log(hit.point);

                }
            }
            else
            {
                actionOBJ.transform.position = targetActOBJ.transform.position;
                Debug.Log("notHit");
            }
            Action();
        }

        if (cameraScript.action == false)
        {
            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            characterController.Move(globalDirection * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 50, 0);
            transform.position = Vector3.MoveTowards(transform.position, action2OBJ.transform.position, actSpeed * Time.deltaTime);
        }
    }

    public void Box1()
    {
        moveDirection.x = knockBackPow;
        moveDirection.z = -knockBackPow;
        Invoke("KnockBackOff", 0.5f);
    }
    public void Box2()
    {
        moveDirection.x = -knockBackPow;
        moveDirection.z = -knockBackPow;
        knockBack = true;
        Invoke("KnockBackOff", 0.5f);
    }
    public void Box3()
    {
        moveDirection.x = -knockBackPow;
        moveDirection.z = knockBackPow;
        knockBack = true;
        Invoke("KnockBackOff", 0.5f);
    }
    public void Box4()
    {
        moveDirection.x = knockBackPow;
        moveDirection.z = knockBackPow;
        knockBack = true;
        Invoke("KnockBackOff", 0.5f);
    }

    void KnockBackOff()
    {
        moveDirection = Vector3.zero;
        knockBack = false;
    }

    void Action()
    {
        cameraScript.action = true;
        Invoke("ActionOff", 1);
    }

    void ActionOff()
    {
        cameraScript.action = false;
        transform.rotation = Quaternion.Euler(nowRotX, nowRotY, nowRotZ);
    }

    void Pause()
    {
        Time.timeScale = pauseState;
        if (pauseState == 0)
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TitleScene");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Action"))
        {
            ActionOff();
        }

        if (other.gameObject.tag == ("Start"))
        {
            gameControllerScript.TAstart();
        }

        if (other.gameObject.tag == ("End"))
        {
            gameControllerScript.TAend();
        }
    }
}

