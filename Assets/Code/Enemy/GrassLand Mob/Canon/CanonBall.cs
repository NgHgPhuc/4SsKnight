using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float AttackDamage;
    void Start()
    {
        if(transform.rotation.y==0)
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0), ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerExternal>().BeingHit(this.AttackDamage);
            collision.GetComponent<PlayerExternal>().BeingKnockBack(new Vector2(2, 0));
            Destroy(gameObject);
        }
    }

    public void attackDamage(float attackDamage)
    {
        this.AttackDamage = attackDamage;
    }
}
