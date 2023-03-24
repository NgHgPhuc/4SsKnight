using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public Vector3 Distance;
    Vector3 ToPos;
    Vector3 FromPos;
    bool PlayerOn;

    void Start()
    {
        FromPos = transform.position;
        ToPos = FromPos + Distance;
    }

    
    void FixedUpdate()
    {
        if(PlayerOn)
        {
            ToPos = FromPos + Distance;
            transform.position = Vector3.MoveTowards(transform.position, ToPos, Time.deltaTime * 5);
        }
        else
        {
            ToPos = FromPos;
            transform.position = Vector3.MoveTowards(transform.position, ToPos, Time.deltaTime * 5);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerOn = true;
        }
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, ToPos, Time.deltaTime * 5);
    //    }
    //}
    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerOn = false;
    }
}
