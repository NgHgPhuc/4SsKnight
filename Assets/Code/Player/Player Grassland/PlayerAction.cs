using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rg2d;

    bool FacingRight;
    float Horizontal;
    PlayerColliderJump playerColliderJump;
    PlayerStats playerStats;
    
    //Combo
    int Combo=0;
    bool CanAttack = true;
    PlayerAttack playerAttack;

    bool IsDash=false;

    //Skill
    bool IsUsingSkill = false;
    float UsingTimeMark;
    float CooldownTimeMark;

    //jump
    int MaxJump;
    int Jumpcount=0;

    //SoundFx
    public GameObject PlayerSound_;
    PlayerSound playerSound;


    void Start()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        FacingRight = true;

        playerColliderJump = transform.Find("Ground Check").gameObject.GetComponent<PlayerColliderJump>();
        playerStats = GetComponent<PlayerStats>();
        playerAttack = GetComponent<PlayerAttack>();

        MaxJump = GetComponent<PlayerStats>().maxJump();

        playerSound = PlayerSound_.GetComponent<PlayerSound>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRun();

        PlayerJump();

        PlayerFall();

        PlayerAttack();

        PlayerDash();

        PlayerSkill();
    }

    void PlayerRun()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (!IsDash)
        {
            rg2d.velocity = new Vector2(Horizontal * playerStats.speed(), rg2d.velocity.y);
        }
        if ((Horizontal < 0 && FacingRight) || (Horizontal > 0 && !FacingRight))
            Flip();
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
            if (Jumpcount == 2) playerSound.Jump1();
        }
        if(playerColliderJump.OnGround)
        {
            Jumpcount = 0;
        }
    }

    void PlayerFall()
    {
        if(rg2d.velocity.y < -0.005)
            playerColliderJump.OnGround = false;
    }
    void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CanAttack)
            {
                CanAttack = false;
                StopDash();
                if(Combo<3)
                Combo++;
            }

        }
    }
    public void EndAttack()
    {
        CanAttack = true;
        Combo = 0;
    }
    public void NextAttack()
    {
        if (Combo == 1) playerSound.Attack1();
        if (Combo == 2) playerSound.Attack2();
        if (Combo == 3) playerSound.Attack3();

        CanAttack = true;
        playerAttack.Attack();
    }

    void PlayerDash()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerColliderJump.OnGround)
        {
            float side = transform.localScale.x;
            rg2d.velocity = new Vector2(side* playerStats.speed() * 3, rg2d.velocity.y);
            IsDash = true;
            playerSound.Dash();
        }
        if(Input.GetKeyUp(KeyCode.Z))
        {
            this.StopDash();
        }
    }

    void PlayerSkill()
    {
        if (CooldownSkill())
        {
            if (Input.GetKeyDown(KeyCode.V) && !IsUsingSkill)
            {
                Invisible();
                playerSound.Invisible();
            }
            if (Time.time > UsingTimeMark + 3 && IsUsingSkill)
            {
                Visible();
            }
        }
    }
    void Invisible()
    {
        gameObject.tag = "Invisible";
        IsUsingSkill = true;
        UsingTimeMark = Time.time;

        Color invisible = Color.white;
        invisible.a = 0.5f;
        GetComponent<SpriteRenderer>().color = invisible;
    }
    void Visible()
    {
        gameObject.tag = "Player";
        IsUsingSkill = false;
        CooldownTimeMark = Time.time;
        CooldownTimeMark = Time.time + 3;

        Color invisible = Color.white;
        invisible.a = 1f;
        GetComponent<SpriteRenderer>().color = invisible;
    }
    bool CooldownSkill()
    {
        if (Time.time > CooldownTimeMark)
            return true;
        return false;
    }
    public void StopDash()
    {
        IsDash = false;
    }
    public bool isDash()
    {
        return IsDash;
    }
    public Vector2 velocity()
    {
        return rg2d.velocity;
    }
    public float horizontal()
    {
        return this.Horizontal;
    }
    public int combo()
    {
        return Combo;
    }
    void RunSound() //in animation - PlayerRun.anim
    {
        playerSound.Run();
    }
}
