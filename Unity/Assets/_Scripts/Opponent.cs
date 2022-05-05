using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for opponent movement,
// the opponent moves to the ball when in range
// Picks the positions for the opponent to shoot
// Allows opponent to hit the ball when colliding with it
public class Opponent : MonoBehaviour
{
    public Transform ball;
    public Transform aiTargetPosition;
    public Transform[] aiTargets;
    public float speed;
    public float inRange;
    float force = 13;
    Vector3 aiPosition;
    
    void Start()
    {
        // starting position of the opponent
        aiPosition = transform.position;
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        // distance between the opponent and the ball.
        float dist = Vector3.Distance(ball.position, transform.position);

        // check if it is in range,
        if (dist <= inRange)
        {
            // move to the ball if in range 
            aiPosition.x = ball.position.x; 
            transform.position = Vector3.MoveTowards(transform.position, aiPosition, speed * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            // randomly chose a point to hit the ball.
            int randomIndex = Random.Range(0, aiTargets.Length);
            Vector3 direction = aiTargets[randomIndex].position - transform.position;
            other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 6, 0);

            // check if opponent was last to hit the ball
            ball.GetComponent<Ball>().lastHit = "opponent";
        }
    }
}
