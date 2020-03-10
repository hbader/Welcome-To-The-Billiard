using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text roundText;
    public Text modifierText;
    public Text gameOver;
    public Button resetButton;

    private int score;
    private int round;
    private int modifier;

    private void Start()
    {
        scoreText.text = "Score: 0";
        roundText.text = "Round 1";
        modifierText.text = "x1";
        score = 0; round = 1; modifier = 1;
        resetButton.gameObject.SetActive(false);
    }

    public void updateScore(float speed)
    {
        score = score + modifier;
        scoreText.text = "Score: " + score;
        if (speed > 8)
        {
            modifier++;
        }
        else
        {
            modifier = 1;
        }
        modifierText.text = "x" + modifier;
    }

    public void updateRound()
    {
        roundText.text = "Round " + ++round;
    }

    public void showGameOver()
    {
        gameOver.text = "Game Over.";
        resetButton.gameObject.SetActive(true);
    }
}
