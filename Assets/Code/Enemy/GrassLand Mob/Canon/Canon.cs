using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    GameObject Range;
    EnemyRange enemyRange;
    bool IsAttacking;

    EnemyStats enemyStats;
    EnemyExternal enemyExternal;

    public GameObject canonBall;

    bool IsRun;


    void Start()
    {
        Range = transform.Find("Range").gameObject;
        enemyRange = Range.GetComponent<EnemyRange>();
        enemyRange.AttackInRange = this.AttackInRange;
        enemyRange.LostRange = this.LostRange;
        IsAttacking = false;

        enemyStats = GetComponent<EnemyStats>();
        enemyExternal = GetComponent<EnemyExternal>();

        canonBall.GetComponent<CanonBall>().attackDamage(enemyStats.attackDamage());
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAttacking)
        {
            GetComponent<Animator>().Play("Canon Attack");
        }
        else GetComponent<Animator>().Play("Canon Idle");
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
    public void CanonAttack()
    {
        //canonBall.GetComponent<CanonBall>().attackDamage(enemyStats.attackDamage());
        Instantiate(canonBall, transform.position, transform.rotation);
    }
}
