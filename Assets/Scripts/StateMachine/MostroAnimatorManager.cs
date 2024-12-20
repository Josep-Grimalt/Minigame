using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MostroAnimatorManager : MonoBehaviour
{
    private Animator animator;
    private StateMachine sm;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sm = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isChasing", sm.IsChasing());
    }
}
