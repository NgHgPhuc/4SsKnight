using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyExternal;

public class BaldPirate : MonoBehaviour
{
    GameObject Sight;
    EnemySight enemySight;

    GameObject Range;
    EnemyRange enemyRange;
    bool IsAttacking;

    EnemyStats enemyStats;
    EnemyExternal enemyExternal;
    EnemyView enemyView;

    bool IsRun;

    public Transform ToDesTrans;
    Vector3 ToDes;
    Vector3 FromDes;
    float MovingMark;
    bool StateShow = false;
    

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
        enemyView = GetComponent<EnemyView>();

        FromDes = transform.position;
        ToDes = ToDesTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        PirateAnimation();

        NormalAction();
    }
    void AttackInSight()
    {
        if(!IsAttacking)
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

    void PirateAnimation()
    {
        if (!IsAttacking)
        {
            if (enemyExternal.isHit())
                GetComponent<Animator>().Play("Bald Pirate Hurt");
            else
            {
                if (IsRun)
                    GetComponent<Animator>().Play("Bald Pirate Run");
                else GetComponent<Animator>().Play("Bald Pirate Idle");
            }
        }
        else GetComponent<Animator>().Play("Bald Pirate Attack");
    }

    void NormalAction()
    {
        if (!IsAttacking)
        {
            if (Time.time > MovingMark + 2 && !StateShow)
            {
                ShowExclamation();
            }
            if (Time.time > MovingMark + 3)
            {
                if (transform.position != ToDes)
                {
                    MovingInNormalAction();
                }
                else
                {
                    SwapDes();
                }
            }
        }
    }
    void ShowExclamation()
    {
        enemyView.ExclamationMark_show();
        StateShow = true;
    }
    void MovingInNormalAction()
    {
        transform.position = Vector3.MoveTowards(transform.position, ToDes, Time.deltaTime * enemyStats.speed());
        IsRun = true;
        if (transform.position.x < ToDes.x)
            TurnSide(1);
        else TurnSide(-1);
    }
    void SwapDes()
    {
        MovingMark = Time.time;
        Vector3 swap = ToDes;
        ToDes = FromDes;
        FromDes = swap;
        IsRun = false;

        StateShow = false;
    }
}
