using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkSkillBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fire;
    GameObject Fire_clone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fire"))
        {
            Destroy(collision);
            Fire_clone = Instantiate(Fire, transform.position, Fire.transform.rotation);
            Fire_clone.tag = "FireBack";
            Fire_clone.GetComponent<PlayerAutumnThrowFire>().AttackDamage = 10;
            Fire_clone.GetComponent<PlayerAutumnThrowFire>().Side = -1f;
            Fire_clone.GetComponent<PlayerAutumnThrowFire>().Flip();
        }
    }
}
