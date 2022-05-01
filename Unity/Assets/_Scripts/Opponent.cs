using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public Transform ball;
    public float speed;
    public float inRange;
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
}
