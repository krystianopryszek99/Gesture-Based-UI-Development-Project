using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public Transform ball;
    public Transform aiTargetPosition;
    public float speed;
    public float inRange;
    float force = 15;
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
            Vector3 direction = aiTargetPosition.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 6, 0);
        }
    }
}
