using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for player movement which is controlled by hand gestures,
// It requires 5 fingers to move the player

public class PlayerMovement : MonoBehaviour
{
    // Link
    public NetworkManager networkManager;

    // Player
    public GameObject Player;

    float posx;

    void FixedUpdate()
    {
        // get the data from network manager
        string data = networkManager.message;

        // parse string to float
        float.TryParse(data, out posx);

        // Player position
        Player.transform.position = new Vector3(posx, 1.0f, 10f);
    }

}
