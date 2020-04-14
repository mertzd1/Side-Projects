using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = "Best: " + GetHighScore().ToString(); //this displays thehigh score right away
    }
    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
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
        scoreText.text = score.ToString(); //this writes teh score to the screen

        if(score > GetHighScore()) //this uses the below mehtod Gethighscore to set the new high score
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }
    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }
}
