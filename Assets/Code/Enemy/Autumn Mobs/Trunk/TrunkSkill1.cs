using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkSkill1 : MonoBehaviour
{
    EnemyStats enemyStats;
    EnemyView enemyView;
    EnemyExternal enemyExternal;
    Animator animator;
    Rigidbody2D rg2d;
    GameObject Player;

    public GameObject TrunkBullet;
    GameObject TrunkBullet_clone;
    float Side;

    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyView = GetComponent<EnemyView>();
        enemyExternal = GetComponent<EnemyExternal>();
        animator = GetComponent<Animator>();
        rg2d = GetComponent<Rigidbody2D>();
        this.Player = GetComponent<Trunk>().Player;
    }
    void Update()
    {
        Side = transform.localScale.x;
    }
    public void Skill1()
    {
        GetComponent<Trunk>().IsAttack = true;
    }
    void TrunkAttack()
    {
        if(!GetComponent<Trunk>().IsSkillEnd)
        {
            TrunkBullet_clone = Instantiate(TrunkBullet, transform.position, transform.localRotation);
            TrunkBullet_clone.GetComponent<TrunkBullet>().attackDamage(enemyStats.attackDamage());
            TrunkBullet_clone.GetComponent<TrunkBullet>().side(transform.localScale.x);
        }

    }
}
