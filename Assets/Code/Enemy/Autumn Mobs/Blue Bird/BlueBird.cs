using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyExternal;

public class BlueBird : MonoBehaviour
{
    EnemyStats enemyStats;
    EnemyExternal enemyExternal;
    EnemyView enemyView;

    public Transform ToDesTrans;
    Vector3 ToDes;
    Vector3 FromDes;
    float MovingMark;

    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyExternal = GetComponent<EnemyExternal>();
        enemyView = GetComponent<EnemyView>();

        FromDes = transform.position;
        ToDes = ToDesTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        NormalAction();

        BlueBirdAnimation();

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void TurnSide(int TargetPos)//-1 mean left, 1 mean right
    {
        Vector3 turn = transform.localScale;
        turn.x = Mathf.Abs(turn.x) * TargetPos;
        transform.localScale = turn;
    }

    void NormalAction()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerExternal>().BeingHit(enemyStats.attackDamage());
        }
    }

    void BlueBirdAnimation()
    {
        if (enemyExternal.isHit())
            GetComponent<Animator>().Play("Blue Bird Hurt");
        else
            GetComponent<Animator>().Play("BlueBird");
    }

    void MovingInNormalAction()
    {
        transform.position = Vector3.MoveTowards(transform.position, ToDes, Time.deltaTime * enemyStats.speed());
        if (transform.position.x < ToDes.x)
            TurnSide(-1);
        else TurnSide(1);
    }
    void SwapDes()
    {
        MovingMark = Time.time;
        Vector3 swap = ToDes;
        ToDes = FromDes;
        FromDes = swap;

    }
}
