using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucumber : MonoBehaviour
{
    GameObject Range;
    EnemyRange enemyRange;
    bool IsAttacking;

    EnemyStats enemyStats;
    EnemyExternal enemyExternal;
    EnemyView enemyView;

    Vector3 ToDes;
    HeadAttack headAttack;

    float TurnSideTime;
    bool StateShow=false;
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

        headAttack = transform.Find("HeadAttack").gameObject.GetComponent<HeadAttack>();
    }

    void Update()
    {
        CucumberAnimation();

        NormalAction();
    }
    void TurnSide()//-1 mean left, 1 mean right
    {
        Vector3 turn = transform.localScale;
        turn.x *= -1; 
        transform.localScale = turn;
    }
    void TurnSideY()
    {
        Vector3 turn = transform.localScale;
        turn.y *= -1;
        transform.localScale = turn;
    }
    void AttackInRange()
    {
        IsAttacking = true;
        headAttack.attackDamage(enemyStats.attackDamage());
    }
    public void StartMovingAttack()
    {
        //MovingAttack = true;
        float side = -transform.localScale.x;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(side*5*enemyStats.speed(), 0), ForceMode2D.Impulse);
    }
    public void EndMovingAttack()
    {
        enemyExternal.BeingDie();
    }

    void CucumberAnimation()
    {
        if (!IsAttacking)
        {
            if (enemyExternal.isHit())
                GetComponent<Animator>().Play("Cucumber Hurt");
            else
            {
                GetComponent<Animator>().Play("Cucumber Idle");
            }
        }
        else GetComponent<Animator>().Play("Cucumber Attack");
    }

    void NormalAction()
    {
        if(Time.time > TurnSideTime+2 && !StateShow)
        {
            enemyView.ExclamationMark_show();
            StateShow = true;          
        }
        if (Time.time > TurnSideTime + 3)
        {
            if(!IsAttacking)
            TurnSide();
            TurnSideTime = Time.time;
            StateShow = false;
        }
    }
    void LostRange()
    {

    }
}
