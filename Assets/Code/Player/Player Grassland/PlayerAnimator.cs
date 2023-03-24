using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerColliderJump playerColliderJump;
    PlayerAction playerAction;
    PlayerExternal playerExternal;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerColliderJump = transform.Find("Ground Check").gameObject.GetComponent<PlayerColliderJump>();
        playerAction = GetComponent<PlayerAction>();
        playerExternal = GetComponent<PlayerExternal>();

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (playerAction.combo() == 0)
                if (playerExternal.isHit())
                    animator.Play("Player Hurt");
                else
                    if (playerAction.isDash())
                    animator.Play("Player Dash");
                    else
                        if (playerColliderJump.OnGround)
                            if (playerAction.horizontal() != 0)
                                animator.Play("PlayerRun");
                            else
                                animator.Play("PlayerIdle");
                        else
                                if (playerAction.velocity().y < -0.005)
                            animator.Play("PlayerFall");
                                else
                                    animator.Play("PlayerJump");
            else
                animator.Play("PlayerAttack " + playerAction.combo().ToString());
        }
        catch (Exception) { }
    }



}
