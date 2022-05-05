using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Link
    public NetworkManager networkManager;

    // Update is called once per frame
    void Update()
    {
        // get the data from network manager
        string data = networkManager.message;
        if (data == "1")
        {
            FindObjectOfType<SceneController>().Pause_Game();
            Debug.Log("one");
        }
        if (data == "2")
        {
            FindObjectOfType<SceneController>().Resume_Game();
            Debug.Log("two");
        }
    }
}
