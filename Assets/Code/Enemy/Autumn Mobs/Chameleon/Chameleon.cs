using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyExternal;

public class Chameleon : MonoBehaviour
{
    GameObject Range;
    EnemyRange enemyRange;
    bool IsAttacking;

    EnemyStats enemyStats;
    EnemyExternal enemyExternal;
    EnemyView enemyView;

    void Start()
    {
        Range = transform.Find("Range").gameObject;
        enemyRange = Range.GetComponent<EnemyRange>();
        enemyRange.AttackInRange = this.AttackInRange;
        enemyRange.LostRange = this.LostRange;
        IsAttacking = false;

        enemyStats = GetComponent<EnemyStats>();
        enemyExternal = GetComponent<EnemyExternal>();
        enemyView = GetComponent<EnemyView>();
    }

    // Update is called once per frame
    void Update()
    {
        ChameleonAnimation();
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

    void ChameleonAnimation()
    {
        if (!IsAttacking)
        {
            if (enemyExternal.isHit())
                GetComponent<Animator>().Play("Chameleon Hurt");
            else
            {
                GetComponent<Animator>().Play("Chameleon Idle");
            }
        }
        else GetComponent<Animator>().Play("Chameleon Attack");
    }
}
