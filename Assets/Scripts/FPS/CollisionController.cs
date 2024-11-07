using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    private GameManager gm;

    private void Awake() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Exit"))
        {
            if(gm.canExit)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
