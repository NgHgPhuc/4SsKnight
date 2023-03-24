using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trunk : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyStats enemyStats;
    EnemyView enemyView;
    EnemyExternal enemyExternal;
    Animator animator;

    public GameObject Player;

    int SkillChose;
    int LastSkillChose = 0;

    public bool IsSkillEnd = true;
    bool IsWaiting = true;
    public bool IsAttack=false;
    public bool IsHurt = false;
    public bool IsBang = false;

    public GameObject DefBySelf;

    int HitTimes = 0;

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
        TrunkAnimation();

        FollowPlayer();
    }

    void TrunkAnimation()
    {
        if (IsHurt) animator.Play("Trunk Hurt");
        else if (IsAttack) animator.Play("Trunk Attack");
            else if (IsBang) animator.Play("Trunk Bangg");
                else if (IsWaiting) animator.Play("Trunk Idle");
    }

    void EndWaiting() //idle in 1.5s
    {
        if (IsWaiting)
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
        SkillChose = rd.Next(1, 50);//1 - 2
        SkillChose = SkillChose / 25 + 1;
        LastSkillChose = SkillChose;
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
        switch (SkillChose)
        {
            case 1:
                GetComponent<TrunkSkill1>().Skill1();
                break;
            case 2:
                GetComponent<TrunkSkill2>().Skill2();
                break;
            default: break;
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

    public void HitByFire()
    {
        IsAttack = false;
        IsBang = false;
        IsHurt = true;
        HitTimes++;
    }
    public void EndHurt()
    {
        IsWaiting = true;
        IsHurt = false;
        if (HitTimes == 4) defBySelf();

    }
    void defBySelf()
    {
        DefBySelf.SetActive(true);
        Invoke("DeactiveDef", 4f);
    }
    void DeactiveDef()
    {
        DefBySelf.SetActive(false);
        HitTimes = 0;
    }
}
