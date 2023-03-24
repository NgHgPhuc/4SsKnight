using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Whale : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyStats enemyStats;
    EnemyView enemyView;
    EnemyExternal enemyExternal;
    Animator animator;

    public GameObject Player;

    int SkillChose;
    int LastSkillChose=0;

    public bool IsRun=false;
    public bool IsSwallow = false;

    public bool IsSkillEnd=true;
    bool IsWaiting=true;

    float BeingHitTimeMark;
    bool BHT=false;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyView = GetComponent<EnemyView>();
        enemyExternal = GetComponent<EnemyExternal>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WhaleAnimation();
        EndBeingHit();

        FollowPlayer();
    }

    void WhaleAnimation()
    {
        if (IsSwallow) animator.Play("Whale Swallow");
        else
            if (IsRun) animator.Play("Whale Run");
            else animator.Play("Whale Idle");
    }

    void EndWaiting() //idle in 3s
    {
        if(IsWaiting)
        {
            RandomSkill();
            IsWaiting = false;
            IsSkillEnd = false;
        }
    }
    void StartWaiting()
    {
        if (IsSkillEnd)
            IsWaiting = true;
    }
    void ShowExclamation()
    {
        if (IsWaiting)
            enemyView.ExclamationMark_show();
    }

    void RandomSkill()
    {
        System.Random rd = new System.Random();
        SkillChose = rd.Next(1, 75);//1 - 2
        SkillChose = SkillChose/25 + 1;
        LastSkillChose = SkillChose;
        Debug.Log(SkillChose);
        UsingSkill();

    }

    void TurnSide(int TargetPos)
    {
        Vector3 turn = transform.localScale;
        turn.x = Mathf.Abs(turn.x) * TargetPos;
        transform.localScale = turn;
    }

    void UsingSkill()
    {
        switch(SkillChose)
        {
            case 1:
                GetComponent<WhaleSkill1>().Skill1();
                break;
            case 2:
                GetComponent<WhaleSkill2>().Skill2();
                break;
            case 3:
                GetComponent<WhaleSkill3>().Skill3();
                break;
            default:break;
        }
    }

    void FollowPlayer()
    {
        if (Player.transform.position.x < transform.position.x)
            TurnSide(1);
        else TurnSide(-1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerExternal>().BeingHit(enemyStats.attackDamage());
        }
    }

    void EndBeingHit()
    {
        if (enemyExternal.isHit())
        {
            if(!BHT)
            {
                BeingHitTimeMark = Time.time;
                BHT = true;
            }
            if (Time.time>BeingHitTimeMark+0.5)
            {
                enemyExternal.EndBeingHit();
                BHT = false;
            }
        }
    }
}
