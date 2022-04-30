using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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
}
