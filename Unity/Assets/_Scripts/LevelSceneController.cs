using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneController : MonoBehaviour
{
    public GameObject mainMenu, instructionsMenu;

    public void Start_Game()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void Show_Instructions()
    {
        mainMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void Quit_Game()
    {
        Debug.Log("Quit the application!");
        Application.Quit(); 
    }
}
