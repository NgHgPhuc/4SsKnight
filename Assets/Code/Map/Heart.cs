using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HealingEffect;
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Invisible"))
        {
            collision.gameObject.GetComponent<PlayerExternal>().Heal(20);
            Destroy(Instantiate(HealingEffect, transform.position, transform.rotation), 0.75f);
            Destroy(gameObject);
        }
    }
}
