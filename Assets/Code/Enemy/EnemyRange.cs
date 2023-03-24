using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void Delegate();
    public Delegate AttackInRange;
    public Delegate LostRange;

    GameObject Target; //Only Player
    void Start()
    {
        Target = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Target = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackInRange();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LostRange();
        }
    }

    public GameObject GetTarget()
    {
        return Target;
    }
}
