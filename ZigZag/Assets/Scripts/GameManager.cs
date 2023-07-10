using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = "Best: " + GetHighScore().ToString();
    }
    public void StartGame() 
    {
        gameStarted = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore",score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }
    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
