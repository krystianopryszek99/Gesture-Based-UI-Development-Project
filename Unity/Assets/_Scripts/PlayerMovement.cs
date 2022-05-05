using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Link
    public NetworkManager networkManager;

    // Player
    public GameObject Player;

    float posx;

    void Update()
    {
        // get the data from network manager
        string data = networkManager.message;

        // parse string to float
        float.TryParse(data, out posx);

        // Player position
        Player.transform.position = new Vector3(posx, 1.0f, 10f);
    }
}
