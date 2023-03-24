using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats playerStats;
    public GameObject AttackPoint;
    [SerializeField] LayerMask EnemyLayer;
    public float AttackRange;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    
    void Update()
    {
        playerStats.attackRange(AttackRange);
    }

    public void Attack()
    {
        Collider2D[] EnemyBeingHit = Physics2D.OverlapCircleAll(AttackPoint.transform.position, AttackRange, EnemyLayer);
        foreach (Collider2D collision in EnemyBeingHit)
        {
            collision.gameObject.GetComponent<EnemyExternal>().BeingHit(playerStats.attackDamage());
        }
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint != null)
            Gizmos.DrawWireSphere(AttackPoint.transform.position, AttackRange);
    }

}
