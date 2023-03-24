using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutumnAnimator : MonoBehaviour
{
    Animator animator;
    PlayerColliderJump playerColliderJump;
    PlayerAutumnAction playerAction;
    PlayerExternal playerExternal;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerColliderJump = transform.Find("Ground Check").gameObject.GetComponent<PlayerColliderJump>();
        playerAction = GetComponent<PlayerAutumnAction>();
        playerExternal = GetComponent<PlayerExternal>();

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (playerAction.canAttack())
                if (playerAction.holding())
                    animator.Play("Player Autumn Wall Sliding");
                else
                    if (playerExternal.isHit())
                        animator.Play("Player Autumn Hurt");
                    else
                        if (playerColliderJump.OnGround)
                            if (playerAction.horizontal() != 0)
                                animator.Play("Player Autumn Running");
                            else
                                animator.Play("Player Autumn Idle");
                        else
                            if (playerAction.velocity().y < -0.005)
                            animator.Play("Player Autumn Fall");
                            else
                                animator.Play("Player Autumn Jump ");
            else
                animator.Play("Player Autumn Attack");
        }
        catch (Exception) { }
    }



}
