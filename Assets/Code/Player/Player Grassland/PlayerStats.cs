using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Jump;
    [SerializeField] float AttackDamage;
    [SerializeField] float MaxHealth;
    [SerializeField] float AttackRange;
    [SerializeField] int MaxJump;
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
    public void speed(float mount)
    {
        Speed += mount;
        if (Speed <= 0) Speed = 1;
    }
	public float jump()
	{
        return this.Jump;
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
        CurrentHealth -= HPmount;
        if (CurrentHealth <= 0) Destroy(gameObject);
    }
    public float attackRange()
    {
        return this.AttackRange;
    }
    public void attackRange(float Range)
    {
        if (Range > 0)
            this.AttackRange = Range;
    }
    public void Heal(float mount)
    {
        if (mount > 0)
        {
            this.CurrentHealth += mount;
            if (this.CurrentHealth > this.MaxHealth)
                this.CurrentHealth = this.MaxHealth;
        }

    }

    public int maxJump()
    {
        return MaxJump;
    }
}

