using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    [SerializeField]
    private string clientIp = "127.0.0.1";

    [SerializeField]
    private int clientPort = 8080;

    int bufferSize = 256;

    UdpClient udpClient;

    IPEndPoint ipEP;

    string message;

    byte[] data;

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
        data = udpClient.Receive(ref ipEP);
        message = Encoding.ASCII.GetString(data, 0, data.Length);
        Debug.Log("Received " + message);
    }
}
