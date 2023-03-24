using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAutumnAction : MonoBehaviour
{
    private Rigidbody2D rg2d;

    bool FacingRight;
    float Horizontal;
    PlayerColliderJump playerColliderJump;
    PlayerStats playerStats;

    //Combo
    bool CanAttack = true;
    PlayerAttack playerAttack;

    //jump
    int MaxJump;
    int Jumpcount = 0;

    //Climb-Hold
    PlayerAutumnHold HoldRight;
    bool Holding;

    public GameObject Fire;
    GameObject Fire_clone;
    PlayerAutumnBag playerAutumnBag;

    //sound
    public GameObject PlayerSound_;
    PlayerSound playerSound;

    void Start()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        FacingRight = true;

        playerColliderJump = transform.Find("Ground Check").gameObject.GetComponent<PlayerColliderJump>();
        playerStats = GetComponent<PlayerStats>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAutumnBag = GetComponent<PlayerAutumnBag>();

        MaxJump = GetComponent<PlayerStats>().maxJump();

        HoldRight = transform.Find("Hold Right").gameObject.GetComponent<PlayerAutumnHold>();

        playerSound = PlayerSound_.GetComponent<PlayerSound>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHolding();

        PlayerHold();

        PlayerRun();

        PlayerJump();

        PlayerFall();

        PlayerAttack();

        PlayerSkill();
    }

    void PlayerRun()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if(!Holding)
        rg2d.velocity = new Vector2(Horizontal * playerStats.speed(), rg2d.velocity.y);
        if ((Horizontal < 0 && FacingRight) || (Horizontal > 0 && !FacingRight))
            Flip();
    }
    void PlayerHold()
    {
        if (Holding)
            rg2d.velocity = new Vector2(0, 0);
    }
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.X) && Jumpcount < MaxJump)
        {
            rg2d.velocity = new Vector2(rg2d.velocity.x, playerStats.speed());
            playerColliderJump.OnGround = false;
            Jumpcount++;

            if (Jumpcount == 1) playerSound.Jump1();
            if (Jumpcount == 2) playerSound.Jump2();
        }
        if (playerColliderJump.OnGround)
        {
            Jumpcount = 0;
        }
    }

    void PlayerFall()
    {
        if (rg2d.velocity.y < -0.005)
            playerColliderJump.OnGround = false;
    }
    void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CanAttack)
            {
                CanAttack = false;
                
            }

        }
    }
    public void Attack_() // in animation
    {
        playerAttack.Attack();
        playerSound.Attack1();
    }
    public void CDAttack()
    {
        CanAttack = true;
    }

    void PlayerSkill()
    {
        if(Input.GetKeyDown(KeyCode.V) && playerAutumnBag.CurrentFireMount>0)
        {
            Fire_clone = Instantiate(Fire, transform.position,Fire.transform.localRotation);
            Fire_clone.GetComponent<PlayerAutumnThrowFire>().AttackDamage = playerStats.attackDamage();
            Fire_clone.GetComponent<PlayerAutumnThrowFire>().Side = transform.localScale.x;
            Fire_clone.GetComponent<PlayerAutumnThrowFire>().Flip();
            playerAutumnBag.CurrentFireMount--;
            playerSound.Fire();
        }
    }
    public Vector2 velocity()
    {
        return rg2d.velocity;
    }
    public float horizontal()
    {
        return this.Horizontal;
    }
    public bool canAttack()
    {
        return this.CanAttack;
    }
    void CheckHolding()
    {
        if(HoldRight.isHold() && Horizontal != 0)//left hold
        {
            Holding = true;
            playerColliderJump.OnGround = true;
        }
        else Holding = false;
    }
    public bool holding()
    {
        return this.Holding;
    }

    void Climb() //in animation
    {
        playerSound.Climb();
    }
    void RunSound() //in animation - PlayerRun.anim
    {
        playerSound.Run();
    }
}
