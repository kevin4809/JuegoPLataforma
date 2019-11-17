using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject canMenu;
    public GameObject canCreditos;


    private void Start()
    {

        if (canCreditos)
        {
            canCreditos.gameObject.SetActive(false);
        }
        if (canMenu)
        {
            canMenu.gameObject.SetActive(false);
        }

    }

    public void ActivarScena(string loadGame)
    {
        switch (loadGame)
        {
            case "Play":
                print("Hola");
                SceneManager.LoadScene("Plataformero");
                
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

            case "R":
                canCreditos.gameObject.SetActive(true);
                canMenu.gameObject.SetActive(false);
                break;

            case "R2":
                canCreditos.gameObject.SetActive(false);
                canMenu.gameObject.SetActive(true);
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
