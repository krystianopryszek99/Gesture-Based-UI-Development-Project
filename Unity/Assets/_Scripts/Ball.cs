using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public string lastHit;
    private int pointsForHit = 1; 
    Vector3 ballPos;

    void Start()
    {
        // the initial position of the ball.
        ballPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall")) 
        {
            if(lastHit == "player")
            {
                FindObjectOfType<GameController>().UpdatePlayerScore(pointsForHit);
            }
            else if(lastHit == "opponent")
            {
                FindObjectOfType<GameController>().UpdateOpponentScore(pointsForHit);
            }
            // reset the ball.
            ResetBall();
        }

        if(other.CompareTag("Net")) 
        {
            if(lastHit == "player")
            {
                FindObjectOfType<GameController>().UpdateOpponentScore(pointsForHit);
            }
            else if(lastHit == "opponent")
            {
                FindObjectOfType<GameController>().UpdatePlayerScore(pointsForHit);
            }
            // reset the ball.
            ResetBall();
        }

        if(other.CompareTag("Out")) 
        {
            if(lastHit == "player")
            {
                FindObjectOfType<GameController>().UpdateOpponentScore(pointsForHit);
            }
            else if(lastHit == "opponent")
            {
                FindObjectOfType<GameController>().UpdatePlayerScore(pointsForHit);
            }
            // reset the ball.
            ResetBall();
        }
    }

    void ResetBall()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = ballPos;
    }
    
}
