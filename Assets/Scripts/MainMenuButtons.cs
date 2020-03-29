using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("gamescene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsPage()
    {
        SceneManager.LoadScene("Options");
    }

    public void MainMenuPage()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
