using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] Image HealthFill;
    [SerializeField] Slider HealthBar;
    [SerializeField] Canvas EnemyHealthBar;
    [SerializeField] GameObject ExclamationMark;
    EnemyStats enemyStats;
    public Canvas Floating;
    GameObject FloatingDamage;
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        HealthBar.maxValue = enemyStats.maxHealth();
        HealthBar.value = enemyStats.currentHealth();
        FloatingDamage = Floating.transform.Find("FloatingDamage").gameObject;
    }

    void Update()
    {
        SetHealthBar();
    }

    void SetHealthBar()
    {
        HealthBar.value = enemyStats.currentHealth();
    }
    public void floatingDamage(float Damage)
    {
        FloatingDamage.GetComponent<TextMeshProUGUI>().SetText("-"+Damage.ToString());
        FloatingDamage.GetComponent<TextMeshProUGUI>().color = Color.red;
        Destroy(Instantiate(Floating, transform.position+new Vector3(0,2,0), transform.rotation).gameObject,1f);
    }
    public void ExclamationMark_show()
    {
        Destroy(Instantiate(ExclamationMark, transform.position + new Vector3(0, 2.2f, 0), transform.rotation), 1f);
    }
}
