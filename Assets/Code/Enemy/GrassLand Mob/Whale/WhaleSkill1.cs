using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WhaleSkill1 : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyStats enemyStats;
    EnemyView enemyView;
    EnemyExternal enemyExternal;
    Animator animator;
    Rigidbody2D rg2d;
    GameObject Player;

    float TimeMark;

    float Side;
    bool OnGround = true;
    bool IsUsingSkill = false;
    bool LastJump = false;

    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyView = GetComponent<EnemyView>();
        enemyExternal = GetComponent<EnemyExternal>();
        animator = GetComponent<Animator>();
        rg2d = GetComponent<Rigidbody2D>();
        this.Player = GetComponent<Whale>().Player;

    }

    // Update is called once per frame
    void Update()
    {
        Side = transform.localScale.x;
        Jump();
        EndJump();
    }

    public void Skill1()
    {
        IsUsingSkill = true;
        GetComponent<Whale>().IsRun = true;
    }

    void Jump()
    {
        if(IsUsingSkill)
            if(OnGround && Time.time > TimeMark+0.5)
            {
                rg2d.AddForce(new Vector2(-Side*3, 9), ForceMode2D.Impulse);
                OnGround = false;
            }
    }

    void EndJump()
    {
        if(IsUsingSkill)
            if(HigherPlayer())
            {
                //rg2d.AddForce(new Vector2(0,-6), ForceMode2D.Impulse);
                rg2d.velocity = new Vector2(0, -8);
                LastJump = true;
            }
    }
    bool HigherPlayer()
    {
        Vector2 origin = transform.position;
        RaycastHit2D[] hit = Physics2D.RaycastAll(origin, Vector2.down);
        foreach(RaycastHit2D player in hit)
        {
            if (player.collider.gameObject.CompareTag("Player"))
                return true;
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            OnGround = true;
            TimeMark = Time.time;
        }
        if (LastJump)
        {
            IsUsingSkill = false;
            LastJump = false;
            GetComponent<Whale>().IsSkillEnd = true;
            GetComponent<Whale>().IsRun = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LastJump)
        {
            IsUsingSkill = false;
            LastJump = false;
            GetComponent<Whale>().IsSkillEnd = true;
            GetComponent<Whale>().IsRun = false;
        }
    }
}
