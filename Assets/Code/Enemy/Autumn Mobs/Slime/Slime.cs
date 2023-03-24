using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update

    EnemyStats enemyStats;
    EnemyExternal enemyExternal;
    EnemyView enemyView;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyExternal = GetComponent<EnemyExternal>();
        enemyView = GetComponent<EnemyView>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerExternal>().BeingHit(enemyStats.attackDamage());
        }
    }
}
