using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject canMenu;


    private void Awake()
    {
        canMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0F;
    }

    public void ActivarScena(string loadGame)
    {
        switch (loadGame)
        {
            case "Play":
                SceneManager.LoadScene("Plataformero");
                print("Hola");
                break;


            case "Exit":
                Application.Quit();
                break;

            case "Return":
                PauseGame();
                canMenu.gameObject.SetActive(false);
                break;

            case "Menu":
                SceneManager.LoadScene("FirstMenu");
                PauseGame();
                break;

            case "Restart":
                SceneManager.LoadScene("Plataformero");
                PauseGame();
                break;


        }


    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
            canMenu.gameObject.SetActive(true);
   
        }

       

    }
    public void PauseGame()
    {
       
        if (Time.timeScale == 1.0F)
        {
            Time.timeScale = 0.0F;
        }
        else
        {
            Time.timeScale = 1.0F;
        }

    }

}
