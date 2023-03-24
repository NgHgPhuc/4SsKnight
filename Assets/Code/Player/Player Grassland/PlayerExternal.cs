using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExternal : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerView playerView;
    Rigidbody2D rg2d;

    public GameObject PlayerExternalSound_;
    PlayerExternalSound playerExternalSound;
    bool IsHit;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerView = GetComponent<PlayerView>();
        rg2d = GetComponent<Rigidbody2D>();
        playerExternalSound = PlayerExternalSound_.GetComponent<PlayerExternalSound>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeingHit(float Damage)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        IsHit = true;
        playerExternalSound.Hurt();
        playerStats.LostHP(Damage);
        playerView.floatingDamage(Damage);
    }
    public void Heal(float mount)
    {
        playerStats.Heal(mount);
        playerView.floatingHeal(mount);
        playerExternalSound.Heal();
    }
    public void BeingKnockBack(Vector2 Force)
    {
        rg2d.AddForce(Force, ForceMode2D.Impulse);
    }
    public void EndBeingHit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        IsHit = false;
    }
    public bool isHit()
    {
        return IsHit;
    }

    public void PlayerDie()
    {
        SceneManager.LoadScene(0);
    }
}
