using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }
}
