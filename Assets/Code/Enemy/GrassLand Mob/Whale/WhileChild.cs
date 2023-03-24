using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float AttackDamage = GetComponent<EnemyStats>().attackDamage();
            GetComponent<EnemyExternal>().BeingDie();
            collision.gameObject.GetComponent<PlayerExternal>().BeingHit(AttackDamage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Whale"))
        {
            float AttackDamage = GetComponent<EnemyStats>().attackDamage();
            GetComponent<EnemyExternal>().BeingDie();
            collision.gameObject.GetComponent<EnemyExternal>().BeingHeal(AttackDamage);
        }
    }
    private void OnDestroy()
    {
        GetComponent<EnemyExternal>().BeingDie();
    }
}
