using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used to launch the game, show instructions, and quit the game
public class LevelSceneController : MonoBehaviour
{
    public GameObject mainMenu, instructionsMenu;

    // starts the game
    public void Start_Game()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // shows the instructions menu
    public void Show_Instructions()
    {
        mainMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    // takes player back to the main menu
    public void Show_Menu()
    {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }

    // quits the game
    public void Quit_Game()
    {
        Debug.Log("Quit the application!");
        Application.Quit(); 
    }
}
