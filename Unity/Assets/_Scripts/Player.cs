using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to hit the ball when colliding with it
public class Player : MonoBehaviour
{
    public Transform ball;

    public Transform targetPosition;

    float force = 15;

    // If the player hits the ball 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 direction = targetPosition.position - transform.position;
            other.GetComponent<Rigidbody>().velocity =
                direction.normalized * force + new Vector3(0, 6, 0);

            // checks if player was last to hit the ball
            ball.GetComponent<Ball>().lastHit = "player";
        }
    }
}
