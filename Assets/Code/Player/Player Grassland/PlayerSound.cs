using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip JumpFx;
    public AudioClip Jump2Fx;
    public AudioClip Attack1Fx;
    public AudioClip Attack2Fx;
    public AudioClip Attack3Fx;
    public AudioClip DashFx;
    public AudioClip RunFx;
    public AudioClip InvisibleFx;
    public AudioClip LandFx;
    public AudioClip FireFx;
    public AudioClip ClimbFx;
    public AudioClip CollectFx;

    public AudioSource GameMusic;
    public AudioSource GameFx;
    void Start()
    {
        GameMusic.Play();
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
    public void Jump1()
    {
        PlayAudioClip(JumpFx);
    }
    public void Jump2()
    {
        PlayAudioClip(Jump2Fx);
    }
    public void Attack1()
    {
        PlayAudioClip(Attack1Fx);
    }
    public void Attack2()
    {
        PlayAudioClip(Attack2Fx);
    }
    public void Attack3()
    {
        PlayAudioClip(Attack3Fx);
    }
    public void Dash()
    {
        PlayAudioClip(DashFx);
    }
    public void Run()
    {
        PlayAudioClip(RunFx);
    }
    public void Invisible()
    {
        PlayAudioClip(InvisibleFx);
    }
    public void Land()
    {
        PlayAudioClip(LandFx);
    }
    public void Fire()
    {
        PlayAudioClip(FireFx);
    }
    public void Climb()
    {
        PlayAudioClip(ClimbFx);
    }
    public void Collect()
    {
        PlayAudioClip(CollectFx);
    }
}
