using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Whale;
    GameObject Block;
    Transform BossFightDes;
    bool StartFight=false;
    void Start()
    {
        Block = transform.Find("Block").gameObject;
        Block.SetActive(false);
        BossFightDes = transform.Find("Boss Fight Des");

    }

    // Update is called once per frame
    void Update()
    {
        if(Whale==null)
        {
            Block.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !StartFight)
        {
            if(collision.transform.position.x > BossFightDes.position.x)
            {
                Whale.SetActive(true);
                Block.SetActive(true);
                StartFight = true;
                if(collision.gameObject.GetComponent<PlayerAction>()!= null)
                    collision.gameObject.GetComponent<PlayerAction>().enabled = true;
                if (collision.gameObject.GetComponent<PlayerAutumnAction>() != null)
                    collision.gameObject.GetComponent<PlayerAutumnAction>().enabled = true;
            }
            else
            {
                collision.transform.position = Vector3.MoveTowards(collision.transform.position, BossFightDes.position, Time.deltaTime * 5);
                if (collision.gameObject.GetComponent<PlayerAction>() != null)
                    collision.gameObject.GetComponent<PlayerAction>().enabled = false;
                if (collision.gameObject.GetComponent<PlayerAutumnAction>() != null)
                    collision.gameObject.GetComponent<PlayerAutumnAction>().enabled = false;
            }
        }
    }
}
