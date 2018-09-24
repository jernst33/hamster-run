using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string mainMenuLevel;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Application.LoadLevel(mainMenuLevel);
    }
}
