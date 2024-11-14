using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    private Animator animator;
    private CharacterController cc;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", cc.velocity.magnitude);
    }
}
