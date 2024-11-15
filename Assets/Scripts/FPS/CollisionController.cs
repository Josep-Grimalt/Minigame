using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject jumpscare;
    private GameManager gm;

    private void Awake() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Exit"))
        {
            if(gm.canExit)
            {
                SceneManager.LoadScene(0);
            }
        }
        
        if (other.gameObject.CompareTag("StateMachine"))
        {
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        jumpscare.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
