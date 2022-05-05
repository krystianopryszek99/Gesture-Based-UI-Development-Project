using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform ball;

    public Transform targetPosition;

    float force = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 direction = targetPosition.position - transform.position;
            other.GetComponent<Rigidbody>().velocity =
                direction.normalized * force + new Vector3(0, 6, 0);

            ball.GetComponent<Ball>().lastHit = "player";
        }
    }
}
