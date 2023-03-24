using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderJump : MonoBehaviour
{
    public bool OnGround { get; set; }
    
    void Start()
    {
        OnGround = true;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            OnGround = true;
        }
    }

    
}
