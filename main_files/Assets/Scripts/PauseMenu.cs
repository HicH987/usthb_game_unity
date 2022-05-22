// using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private InputMaster controls;
    private CharacterController controller;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public bool GameOver = false;
    // Update is called once per frame
    bool b;

    void Awake()
    {
        controls = new InputMaster();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        if (controls.Player.Pause.triggered)
        {
            // Debug.Log("ESCAPE !!");
            if(!GameOver)//si on est dans GameOverMenu désactiver PauseMenu
            {
                if (GameIsPaused)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Resume();
                }else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("LoadMenu..");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit..");
    }

    
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
