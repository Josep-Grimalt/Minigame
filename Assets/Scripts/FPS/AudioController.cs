using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource screamerSrc;
    [SerializeField] private AudioSource footstepSrc;
    [SerializeField] private AudioMixer mixer;

    private CharacterController cc;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRunning && cc.velocity.magnitude > 0.1)
        {
            footstepSrc.Play();
            isRunning = true;
        }
        else if(isRunning && cc.velocity.magnitude < 0.1)
        {
            isRunning = false;
            footstepSrc.Stop();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("StateMachine"))
        {
            footstepSrc.Stop();
            screamerSrc.Play();
        }
    }
}
