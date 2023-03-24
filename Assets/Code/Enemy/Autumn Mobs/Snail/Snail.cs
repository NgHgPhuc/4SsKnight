using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyExternal;

public class Snail : MonoBehaviour
{
    GameObject Sight;
    EnemySight enemySight;

    EnemyStats enemyStats;
    EnemyExternal enemyExternal;
    EnemyView enemyView;

    bool IsRun;



    void Start()
    {
        Sight = transform.Find("Sight").gameObject;
        enemySight = Sight.GetComponent<EnemySight>();
        enemySight.AttackInSight = this.AttackInSight;
        enemySight.LostSight = this.LostSight;

        enemyStats = GetComponent<EnemyStats>();
        enemyExternal = GetComponent<EnemyExternal>();
        enemyView = GetComponent<EnemyView>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    void AttackInSight()
    {
        GetComponent<Animator>().Play("Snail Walk");
        GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyStats.speed(), 0);
    }
    void LostSight()
    {
    }
    void TurnSide(int TargetPos)//-1 mean left, 1 mean right
    {
        Vector3 turn = transform.localScale;
        turn.x = Mathf.Abs(turn.x) * TargetPos;
        transform.localScale = turn;
    }
}
