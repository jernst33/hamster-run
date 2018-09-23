using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string playRhinoLevel;

	public void PlayGame()
    {
        Application.LoadLevel(playRhinoLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
