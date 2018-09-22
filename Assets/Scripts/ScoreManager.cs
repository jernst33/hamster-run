using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreTracker;
    public float highScoreTracker;

    public float pointsPerSecond;

    public bool isAlive;

    void Start () {
		if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreTracker = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	void Update () {
        if (isAlive)
        {
            scoreTracker += pointsPerSecond * Time.deltaTime;
        }
        if (scoreTracker > highScoreTracker)
        {
            highScoreTracker = scoreTracker;
            PlayerPrefs.SetFloat("HighScore", highScoreTracker);
        }
        scoreText.text = "Score: " + Mathf.Round(scoreTracker);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreTracker);
	}

    public void AddToScore(int addScore)
    {
        scoreTracker += addScore;
    }
}
