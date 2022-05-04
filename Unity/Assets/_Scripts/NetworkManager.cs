using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    [SerializeField] private string clientIp = "127.0.0.1";
    [SerializeField] private int clientPort = 8080;
    int bufferSize = 256;
    UdpClient udpClient;
    IPEndPoint ipEP;
    string message;
    byte[] data;
    public Transform ball;
    public Transform targetPosition;
    float force = 15;

    // Start is called before the first frame update
    void Start()
    {
        udpClient = new UdpClient(clientPort);
        data = new byte[bufferSize];
        ipEP = new IPEndPoint(IPAddress.Parse(clientIp), clientPort);
    }

    // Update is called once per frame
    void Update()
    {
        if (udpClient.Available > 0)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udpClient.Receive(ref remoteEP);
            string message = Encoding.ASCII.GetString(data);
            print (message);

            //float posx = float.Parse(message);
            //stransform.position = new Vector3(posx, 1.0f, 10f);

             if (message == "Left")
                {
                   
                    Debug.Log("LEFT");
                }
                if (message == "Right")
                {
                   
                    Debug.Log("RIGHT");
                }
        }

        PlayerMovement();
    }

    private void PlayerMovement()
    {
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        { 
            this.transform.Translate(-0.5f, 0, 0);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            Vector3 direction = targetPosition.position - transform.position;
            other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 6, 0);
            
            ball.GetComponent<Ball>().lastHit = "player";
        }
    }
}
