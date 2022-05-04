using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject pauseMenu, optionsMenu, winnerMenu, gameOverMenu;

    public void Resume_Game()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Debug.Log("Un-paused game");
    }

    public void Restart_Game()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void Pause_Game()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Debug.Log("Paused game");
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void showWinnerMenu()
    {
        winnerMenu.SetActive(true);
    }

    public void showGameoverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
