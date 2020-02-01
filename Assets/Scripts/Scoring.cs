using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public const int scoreValue = 1;
    public GameObject scoreText;
    public GameObject gameOverMessage;
    public static int score = 0;
    public static bool gameOver = false;

    void Update()
    {
        if (!gameOver)
        {
            scoreText.GetComponent<Text>().text = "SCORE : " + score;
            gameOverMessage.GetComponent<Text>().text = " ";
        }

        else
        {
            gameOverMessage.GetComponent<Text>().text = "GAME OVER";

        }

        if(score >= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
