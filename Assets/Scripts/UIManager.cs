using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI modifierText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameOver;
    public Button resetButton;
    public Button mainMenuButton;

    private int score;
    private int round;
    private int modifier;

    private void Start()
    {
        scoreText.SetText("Score: {0}", 0);
        roundText.SetText("Round {0}",0);
        modifierText.SetText("x1");
        highScoreText.SetText("Highscore: {0}", PlayerPrefs.GetInt("Highscore", 0));
        score = 0; round = 0; modifier = 1;
        //resetButton.gameObject.SetActive(false);
        //mainMenuButton.gameObject.SetActive(false);
    }

    public void updateScore(float speed)
    {
        score = score + modifier;
        scoreText.SetText("Score: {0}", score);
        if (speed > 8)
        {
            modifier++;
        }
        else
        {
            modifier = 1;
        }
        modifierText.SetText( "x{0}", modifier);
    }

    public void updateRound()
    {
        roundText.SetText("Round {0}", ++round);
    }

    public void showGameOver()
    {
        gameOver.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        if(PlayerPrefs.GetInt("Highscore") < score) {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.SetText("Highscore: {0}", score);
        }
        
    }
}
