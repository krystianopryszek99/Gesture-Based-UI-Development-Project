using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

// This script is used to receive data from the python server 
public class NetworkManager : MonoBehaviour
{
    // used to start a thread
    Thread receiveThread;

    // UdpClient will parse the pre-defined address for data, which will be used to call the necessary methods
    UdpClient udpClient;

    [SerializeField] private string clientIp = "127.0.0.1";

    //stores the port number
    [SerializeField] private int clientPort = 8080;

    public bool startRecieving = true;

    public string message;

    public void Start()
    {
        InitializeUDP();
    }

    // This method creates a new thread
    private void InitializeUDP()
    {
        Debug.Log("UDP Initialized");

        // receiveThread is initialized as a new Thread
        receiveThread = new Thread(new ThreadStart(ReceiveData));

        // set as Background so that it runs parallel to code
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // receive Data
    private void ReceiveData()
    {
        // Variable udpClient is assigned port
        udpClient = new UdpClient(clientPort);

        // while data is being received
        while (startRecieving)
        {
            try
            {
                //IP Endpoint
                IPEndPoint anyIP =
                new IPEndPoint(IPAddress.Parse(clientIp), clientPort);

                // Data read from the IP Endpoint declared above stored in the variable data in binary form
                byte[] data = udpClient.Receive(ref anyIP);

                // Data is encoded to a utf-8 string format and stored in the text variable.
                message = Encoding.UTF8.GetString(data);
                Debug.Log (message);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    void OnDisable()
    {
        if (receiveThread != null)
            receiveThread.Abort();

        udpClient.Close();
    }
}
