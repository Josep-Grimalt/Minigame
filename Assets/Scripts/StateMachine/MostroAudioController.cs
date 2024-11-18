using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostroAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource runSrc;
    [SerializeField] private AudioSource walkSrc;

    private StateMachine sm;
    private bool wasChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        sm = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sm.HasHunt())
        {
            runSrc.Stop();
            walkSrc.Stop();
            return;
        }

        if(!wasChasing && sm.IsChasing())
        {
            runSrc.Play();
            walkSrc.Stop();
            wasChasing = true;
        }
        else if(wasChasing && !sm.IsChasing())
        {
            runSrc.Stop();
            walkSrc.Play();
            wasChasing = false;
        }
    }
}
