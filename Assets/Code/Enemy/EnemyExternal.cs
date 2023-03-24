using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExternal : MonoBehaviour
{
    EnemyStats enemyStats;
    EnemyView enemyView;
    Rigidbody2D rg2d;
    bool IsHit;

    public delegate void EnemyDie();
    public EnemyDie enemyDie;
    public GameObject EnemyDeathEffect;
    EnemyDrop enemyDrop;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyView = GetComponent<EnemyView>();
        rg2d = GetComponent<Rigidbody2D>();

        if (GetComponent<EnemyDrop>() != null)
            enemyDrop = GetComponent<EnemyDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeingHit(float Damage)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("EndBeingHit", 0.5f);
        IsHit = true;
        enemyStats.LostHP(Damage);
        enemyView.floatingDamage(Damage);
        if (enemyStats.currentHealth() <= 0)
        {
            //enemyDie();
            this.BeingDie();
        }
    }
    public void BeingKnockBack(Vector2 Force)
    {
        rg2d.AddForce(Force, ForceMode2D.Impulse);
    }
    public void EndBeingHit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        IsHit = false;
    }
    public bool isHit()
    {
        return IsHit;
    }
    public void BeingDie()
    {
        if (enemyDrop != null)
            enemyDrop.Drop();

        Destroy(gameObject);
        Destroy(Instantiate(EnemyDeathEffect, transform.position, transform.rotation), 0.5f);

    }
    public void BeingHeal(float HealMount)
    {
        if(HealMount>0)
        enemyStats.Healing(HealMount);

    }

}
