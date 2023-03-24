using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MainCam : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Background;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ToDes = Player.transform.position + new Vector3(0, 3, -10);
        Vector3 BackgroundDes = Player.transform.position + new Vector3(0, 3, 0);
        transform.position = Vector3.MoveTowards(transform.position, ToDes, Time.time * 5);
        Background.transform.position = Vector3.MoveTowards(Background.transform.position, BackgroundDes, Time.time * 5);
    }
}
