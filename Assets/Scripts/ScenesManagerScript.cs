using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SettingsMenu;


    void Start()
    {
        if (loadingScreen) loadingScreen.SetActive(false);
        if (MainMenu) MainMenu.SetActive(true);
        if (SettingsMenu) SettingsMenu.SetActive(false);
    }

    void Update()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex == 2 || activeSceneIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartScene();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MainMenuScene();
            }
        }
    }

    private void MainMenuScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    void RestartScene()
    {
        if (loadingScreen) loadingScreen.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        if (loadingScreen) loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }

    public void ShowSettings()
    {
        if (loadingScreen) loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadDeathScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void LoadWinScene()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
