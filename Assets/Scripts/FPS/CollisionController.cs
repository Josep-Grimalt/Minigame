using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject jumpscare;
    [SerializeField] private AudioClip clip;
    private GameManager gm;
    private CharacterController cc;

    private void Awake() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        cc = GetComponent<CharacterController>();
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
        cc.enabled = false;

        yield return new WaitForSeconds(clip.length - 1);
        SceneManager.LoadScene(0);
    }
}
