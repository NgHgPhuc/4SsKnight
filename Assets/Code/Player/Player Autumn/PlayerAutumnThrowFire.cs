using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutumnThrowFire : MonoBehaviour
{
    // Start is called before the first frame update
    public float AttackDamage;
    public float Side;
    void Start()
    {
        Destroy(gameObject, 2f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Side * 10, 0),ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trunk"))
        {
            collision.gameObject.GetComponent<EnemyExternal>().BeingHit(AttackDamage * 3);
            collision.gameObject.GetComponent<Trunk>().HitByFire();
            Destroy(gameObject);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyExternal>().BeingHit(AttackDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }

        if(gameObject.CompareTag("FireBack") && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerExternal>().BeingHit(AttackDamage);
            Destroy(gameObject);
        }

    }
    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x = Side;
        transform.localScale = localScale;
    }
}
