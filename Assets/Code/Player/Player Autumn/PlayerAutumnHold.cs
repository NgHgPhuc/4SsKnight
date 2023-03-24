using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutumnHold : MonoBehaviour
{
    // Start is called before the first frame update
    bool IsHold = false;
    BoxCollider2D BoxHold;
    void Start()
    {
        BoxHold = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsHold = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsHold = false;
        }
    }
    public bool isHold()
    {
        return this.IsHold;
    }
}
