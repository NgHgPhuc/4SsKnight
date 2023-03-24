
using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float AttackDamage;
    [SerializeField] float MaxHealth;
    float CurrentHealth;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
    }

    public float speed()
    {
        return this.Speed;
    }
    public float attackDamage()
    {
        return this.AttackDamage;
    }
    public float maxHealth()
    {
        return this.MaxHealth;
    }
    public float currentHealth()
    {
        return this.CurrentHealth;
    }
    public void LostHP(float HPmount)
    {
        if (HPmount >= 0)
            CurrentHealth -= HPmount;
        else Debug.Log("Enemy Stats - LostHP fuction: negative HPmount lost!");
    }
    public void Healing(float HealMount)
    {
        if (HealMount > 0)
        {
            this.CurrentHealth += HealMount;
            if (this.CurrentHealth > this.MaxHealth)
                this.CurrentHealth = this.MaxHealth;
        }    
    }
}

