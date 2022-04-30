using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

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

    [SerializeField]
    public Vector3 object_translation = new Vector3();

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
            data = udpClient.Receive(ref ipEP);
            message = Encoding.ASCII.GetString(data, 0, data.Length);
            Debug.Log("Received " + message);
            UpdateTranslation(message);
            MoveObject(object_translation);
        }
        
    }

    private void UpdateTranslation(string input)
    {
        string[] buffer;
        buffer = input.Split(',');
        object_translation.x = (float)Convert.ToDouble(buffer[0]);

        
    }

    private void MoveObject(Vector3 translation)
    {
        transform.position = translation;
        
    }
}
