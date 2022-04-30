using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            //other.GetComponent<Rigidbody>().velocity = direction.normalized * currentShot.hitForce + new Vector3(0, currentShot.upForce, 0);

            //Vector3 ballDirection = ballDirection.position - transform.position;
            //TargetPosition.position = aimTargetInitialPosition;
        }
    }
}
