using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text playerScoreText = null;
    public Text opponentScoreText = null;
    int playerScore = 0;
    int opponentScore = 0;
    [SerializeField] float scoreToGet = 5;

    void Start()
    {
        playerScoreText.text = "Player: " + playerScore.ToString();
        opponentScoreText.text = "Opponent: " + opponentScore.ToString();
    }

    public void UpdatePlayerScore(int s)
    {
        playerScore += s;

        if(playerScoreText != null)
        {
            // update the text
            playerScoreText.text = "Player: " + playerScore.ToString();
        }
        // if the player wins
        if(playerScore == scoreToGet)
        {
            Debug.Log("You Won!");
            // Show winner menu
            FindObjectOfType<SceneController>().showWinnerMenu();
        }
    }

    public void UpdateOpponentScore(int s)
    {
        opponentScore += s;

        if(opponentScoreText != null)
        {
            // update the text
            opponentScoreText.text = "Opponent: " + opponentScore.ToString();
        }
        // if the opponent wins
        if(opponentScore == scoreToGet)
        {
            Debug.Log("Opponent Wins!");
            // Show gameover menu
            FindObjectOfType<SceneController>().showGameoverMenu();
        }
    }
}
