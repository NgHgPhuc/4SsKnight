using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkSkill2 : MonoBehaviour
{
    EnemyStats enemyStats;
    public GameObject TrunkStun;
    GameObject TrunkStun_clone;
    void Start()
    {
        enemyStats = gameObject.GetComponent<EnemyStats>();
    }

    public void Skill2()
    {
        GetComponent<Trunk>().IsBang = true;
        TrunkStun_clone = Instantiate(TrunkStun, transform.position, transform.rotation);
        TrunkStun_clone.GetComponent<TrunkStun>().AttackDamage = enemyStats.attackDamage();
    }
    
    void Update()
    {
        if(!GetComponent<Trunk>().IsBang)
        {
            if (TrunkStun_clone != null)
                Destroy(TrunkStun_clone);
        }
    }

    void InstStun()
    {
    }
}
