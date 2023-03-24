using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : MonoBehaviour
{
    // Start is called before the first frame update
    float AttackDamage;
    float Side;
    void Start()
    {
        Destroy(gameObject, 2f);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(-Side*6, 0),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerExternal>().BeingHit(this.AttackDamage);
            Destroy(gameObject);
        }
    }

    public void attackDamage(float AttackDamage)
    {
        this.AttackDamage = AttackDamage;
    }
    public void side(float Side)
    {
        this.Side = Side;
    }
}
