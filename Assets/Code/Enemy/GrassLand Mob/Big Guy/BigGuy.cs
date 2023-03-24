using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuy : MonoBehaviour
{
    GameObject Sight;
    EnemySight enemySight;

    GameObject Range;
    EnemyRange enemyRange;
    bool IsAttacking;

    EnemyStats enemyStats;
    EnemyExternal enemyExternal;

    bool IsRun;

    bool Sleeping=true;

    void Start()
    {
        Sight = transform.Find("Sight").gameObject;
        enemySight = Sight.GetComponent<EnemySight>();
        enemySight.AttackInSight = this.AttackInSight;
        enemySight.LostSight = this.LostSight;

        Range = transform.Find("Range").gameObject;
        enemyRange = Range.GetComponent<EnemyRange>();
        enemyRange.AttackInRange = this.AttackInRange;
        enemyRange.LostRange = this.LostRange;
        IsAttacking = false;

        enemyStats = GetComponent<EnemyStats>();
        enemyExternal = GetComponent<EnemyExternal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Sleeping) //dont do anything while sleeping
            if (!IsAttacking)
            {
                if (enemyExternal.isHit())
                    GetComponent<Animator>().Play("Big Guy Hurt");
                else
                {
                    if (IsRun)
                        GetComponent<Animator>().Play("Big Guy Run");
                    else GetComponent<Animator>().Play("Big Guy Idle");
                }
            }
            else GetComponent<Animator>().Play("Big Guy Attack");
    }
    void AttackInSight()
    {
        if(!Sleeping) //dont do anything while sleeping
            if (!IsAttacking)
            {
                IsRun = true;
                transform.position = Vector3.MoveTowards(transform.position, enemySight.GetTarget().transform.position, enemyStats.speed() * Time.deltaTime);
                if (transform.position.x < enemySight.GetTarget().transform.position.x)
                    TurnSide(1);
                else TurnSide(-1);
            }
    }
    void LostSight()
    {
        if (!Sleeping) //dont do anything while sleeping
            IsRun = false;
    }
    void TurnSide(int TargetPos)//-1 mean left, 1 mean right
    {
        Vector3 turn = transform.localScale;
        turn.x = Mathf.Abs(turn.x) * TargetPos;
        transform.localScale = turn;
    }
    void AttackInRange()
    {
        IsAttacking = true;
    }
    void LostRange()
    {
        IsAttacking = false;
    }
    public void CauseDamage()
    {
        enemyRange.GetTarget().GetComponent<PlayerExternal>().BeingHit(enemyStats.attackDamage());
    }
    public void IntoSleeping()
    {
        Sleeping = true;
    }
    public void OuttoSleeping()
    {
        Sleeping = false;
        GetComponent<EnemyView>().ExclamationMark_show();
    }
    //public void ExclamationMark_show()
    //{
    //    GetComponent<EnemyView>().ExclamationMark_show();
    //}
}
