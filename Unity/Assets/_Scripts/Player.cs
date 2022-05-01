using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public Transform targetPosition;
    float force = 15;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        { 
            this.transform.Translate(-0.5f, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Vector3 direction = targetPosition.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 6, 0);
        }
    }
}
