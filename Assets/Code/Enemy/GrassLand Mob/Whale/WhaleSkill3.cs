using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleSkill3 : MonoBehaviour
{
    EnemyStats enemyStats;
    EnemyView enemyView;
    EnemyExternal enemyExternal;
    Animator animator;
    Rigidbody2D rg2d;
    GameObject Player;

    public GameObject WhaleChild;
    public GameObject SummonCircle;
    GameObject SummonCircle_clone;
    public Transform SummonRange1;
    public Transform SummonRange2;
    Transform SummonRange1_;
    Transform SummonRange2_;

    float SummonMark=0;

    float Side;
    bool IsUsingSkill = false;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        enemyView = GetComponent<EnemyView>();
        enemyExternal = GetComponent<EnemyExternal>();
        animator = GetComponent<Animator>();
        rg2d = GetComponent<Rigidbody2D>();
        this.Player = GetComponent<Whale>().Player;

        SummonRange1_ = SummonRange1;
        SummonRange2_ = SummonRange2;

    }
    void Update()
    {
        Side = transform.localScale.x;
        Summon();
    }
    public void Skill3()
    {
        IsUsingSkill = true;
        GetComponent<Whale>().IsRun = true;
        SummonCircle_clone=Instantiate(SummonCircle, transform.position, transform.rotation);
    }

    void Summon()
    {
        if(IsUsingSkill)
            if (enemyExternal.isHit())
                EndUsingSkill();
            else
            {
                if(Time.time > SummonMark)
                {
                    System.Random rd = new System.Random();
                    int SummonPosx = 0;
                    if(SummonRange1_.position.x< SummonRange2_.position.x)
                        SummonPosx = rd.Next((int)SummonRange1_.position.x, (int)SummonRange2_.position.x);
                    else SummonPosx = rd.Next((int)SummonRange2_.position.x, (int)SummonRange1_.position.x);

                    Vector3 SummonPos = new Vector3(SummonPosx, transform.position.y + 15, 0);
                    Instantiate(WhaleChild, SummonPos, transform.rotation);
                    SummonMark = Time.time + 2;
                }
            }
    }

    void EndUsingSkill()
    {
        IsUsingSkill = false;
        GetComponent<Whale>().IsSkillEnd = true;
        GetComponent<Whale>().IsRun = false;
        Destroy(SummonCircle_clone);
    }
    private void OnDestroy()
    {
        Destroy(SummonCircle_clone);
    }
}
