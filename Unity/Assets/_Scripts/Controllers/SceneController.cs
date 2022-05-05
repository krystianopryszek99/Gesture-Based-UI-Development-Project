using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used to control the game scene menus
public class SceneController : MonoBehaviour
{
    public GameObject pauseMenu, winnerMenu, gameOverMenu;
  
    // resume the game
    public void Resume_Game()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("GameScene")) 
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            Debug.Log("Un-paused game");
        }
    }

    // restart the game
    public void Restart_Game()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("GameScene")) 
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }

    // pauses the game
    public void Pause_Game()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("GameScene")) 
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Debug.Log("Paused game");
        }
    }

    // takes player back to the main menu
    public void Main_Menu()
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("GameScene")) 
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    // display the winner and gameover menu
    public void showWinnerMenu()
    {
        winnerMenu.SetActive(true);
    }

    public void showGameoverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
