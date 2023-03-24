using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleSkill2 : MonoBehaviour
{
    EnemyStats enemyStats;
    EnemyView enemyView;
    EnemyExternal enemyExternal;
    Animator animator;
    Rigidbody2D rg2d;
    GameObject Player;

    bool IsUsingSkill=false;
    float Side;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyView = GetComponent<EnemyView>();
        enemyExternal = GetComponent<EnemyExternal>();
        animator = GetComponent<Animator>();
        rg2d = GetComponent<Rigidbody2D>();
        this.Player = GetComponent<Whale>().Player;
    }
    void Update()
    {

        Side = transform.localScale.x;

        WhaleDash();
    }
    public void Skill2()
    {
        IsUsingSkill = true;
        GetComponent<Whale>().IsSwallow = true;
    }
    void WhaleDash()
    {
        if(IsUsingSkill)
            if(SeePlayer())
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-Side * enemyStats.speed() * 3, 0);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                EndUsingSkill();
            }
    }
    bool SeePlayer()
    {
        Vector2 origin = transform.position;
        Vector2 Size = new Vector2(100, 100);
        Vector2 Direction = Side * Vector2.left;
        RaycastHit2D[] hit = Physics2D.BoxCastAll(origin, Size, 0, Direction);
        foreach (RaycastHit2D player in hit)
        {
            if (player.collider.gameObject.CompareTag("Player"))
                return true;
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsUsingSkill)
        {
            EndUsingSkill();
        }
    }
    void EndUsingSkill()
    {
        IsUsingSkill = false;
        GetComponent<Whale>().IsSkillEnd = true;
        GetComponent<Whale>().IsSwallow = false;
    }
}
