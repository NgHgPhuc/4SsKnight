using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerAutumnBag>().CollectFire();
            Destroy(gameObject);
        }
    }
}
