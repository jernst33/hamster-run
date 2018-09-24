using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestructor[] platformList;

    private ScoreManager scoreManager;

    public DeathMenu deathScreen;
    public GameObject pauseButton;

	void Start () {

        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
//        deathScreen.gameObject.SetActive(false);
	}
	
	void Update () {
		
	}

    public void RestartGame()
    {
        // StartCoroutine("RestartGameCo");
        scoreManager.isAlive = false;
        thePlayer.gameObject.SetActive(false);
        pauseButton.SetActive(false);
        deathScreen.gameObject.SetActive(true);

    }

    public void Reset()
    {
        platformList = FindObjectsOfType<PlatformDestructor>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        scoreManager.scoreTracker = 0;
        scoreManager.isAlive = true;
        pauseButton.SetActive(true);
        deathScreen.gameObject.SetActive(false);

    }

    /* public IEnumerator RestartGameCo()
    {
        scoreManager.isAlive = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestructor>();

        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        scoreManager.scoreTracker = 0;
        scoreManager.isAlive = true;
    } */
}
