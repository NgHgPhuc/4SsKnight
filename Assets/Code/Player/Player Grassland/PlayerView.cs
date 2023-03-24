using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] Image HealthFill;
    [SerializeField] Slider HealthBar;
    [SerializeField] Canvas PlayerHealthBar;
    [SerializeField] Canvas Floating;
    GameObject FloatingDamage;

    PlayerStats playerStats;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        HealthBar.maxValue = playerStats.maxHealth();
        HealthBar.value = playerStats.currentHealth();
        FloatingDamage = Floating.transform.Find("FloatingDamage").gameObject;
    }

    void Update()
    {
        SetHealthBar();
    }

    void SetHealthBar()
    {
        HealthBar.value = playerStats.currentHealth();
        HealthFill.color = gradient.Evaluate(HealthBar.normalizedValue);
    }
    public void floatingDamage(float Damage)
    {
        FloatingDamage.GetComponent<TextMeshProUGUI>().SetText("-" + Damage.ToString());
        FloatingDamage.GetComponent<TextMeshProUGUI>().color = Color.red;
        Destroy(Instantiate(Floating, transform.position + new Vector3(0, 2, 0), transform.rotation).gameObject, 1f);
    }
    public void floatingHeal(float mount)
    {
        FloatingDamage.GetComponent<TextMeshProUGUI>().SetText("+" + mount.ToString());
        FloatingDamage.GetComponent<TextMeshProUGUI>().color = Color.green;
        Destroy(Instantiate(Floating, transform.position + new Vector3(0, 2, 0), transform.rotation).gameObject, 1f);
    }
}
