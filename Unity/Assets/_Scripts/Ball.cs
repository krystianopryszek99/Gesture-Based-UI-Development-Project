using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used to determine who last hit the ball,
// set the points for the hit
// resets the position of the ball and the opponent to the initial position
public class Ball : MonoBehaviour
{
    public string lastHit;
    [SerializeField] private int pointsForHit = 1; 
    Vector3 ballPos;
    Vector3 opponentPos;

    void Start()
    {
        // the initial position of the ball.
        ballPos = transform.position;
        opponentPos = transform.position;
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
            // reset the opponent
            transform.position = opponentPos;
            // reset the ball.
            Reset();
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
            Reset();
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
            Reset();
        }
    }

    void Reset()
    {
        // reset the ball
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = ballPos;
    }
    
}
