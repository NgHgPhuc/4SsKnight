using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAttack : MonoBehaviour
{
    float AttackDamage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerExternal>().BeingHit(AttackDamage);
            GetComponentInParent<Cucumber>().EndMovingAttack();
        }
    }
    public void attackDamage(float AttackDamage)
    {
        this.AttackDamage = AttackDamage;
    }
}
