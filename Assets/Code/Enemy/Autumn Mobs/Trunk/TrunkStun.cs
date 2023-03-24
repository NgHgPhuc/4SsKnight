using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkStun : MonoBehaviour
{
    // Start is called before the first frame
    //
    public float AttackDamage;
    GameObject Player;
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
            Player = collision.gameObject;
            Player.GetComponent<PlayerExternal>().BeingHit(AttackDamage);
            //Player.GetComponent<PlayerStats>().speed(-2);
            //Invoke("SetDft", 2f);
        }
    }

    private void OnDestroy()
    {
        //SetDft();
    }
    void SetDft()
    {
        //Player.GetComponent<PlayerStats>().speed(2);
    }
}
