using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExternalSound : MonoBehaviour
{
    public AudioClip HurtFx;
    public AudioClip HealFx;


    public AudioSource GameFx;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayAudioClip(AudioClip audioClip)
    {
        this.GameFx.clip = audioClip;
        this.GameFx.Play();
    }
    public void Hurt()
    {
        PlayAudioClip(HurtFx);
    }
    public void Heal()
    {
        PlayAudioClip(HealFx);
    }
    
}
