using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    int titleNom = 0;
    float timer = 0;
    [SerializeField] GameObject[] titleButtonEffect = new GameObject[2];
    void Start()
    {
        titleButtonEffect[0].SetActive(false);
        titleButtonEffect[1].SetActive(false);
        titleButtonEffect[titleNom].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetAxisRaw("Vertical") != 0 && timer > 0.1f)
        {
            timer = 0;
            titleButtonEffect[titleNom].SetActive(false);
            titleNom = 1 - titleNom;
            titleButtonEffect[titleNom].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(titleNom == 0)
            {
                StartButton();
            }

            if(titleNom == 1)
            {
                ExitButton();
            }
        }
    }

    void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    void ExitButton() 
    { 
        Application.Quit();
    }
}
