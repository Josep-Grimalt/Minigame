using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    private GameManager gm;

    private void Awake() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StateMachine"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Exit"))
        {
            if(gm.canExit)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
