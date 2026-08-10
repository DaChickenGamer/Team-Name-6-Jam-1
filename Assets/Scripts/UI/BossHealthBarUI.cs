using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarUI : MonoBehaviour
{
    private Slider _bossHealthBar;
    private EnemyHealth _enemyHealth;
    
    void Start()
    {
        _enemyHealth = GetComponentInParent<EnemyHealth>();
        _bossHealthBar = GetComponent<Slider>();

        _bossHealthBar.wholeNumbers = true;
        _bossHealthBar.maxValue = _enemyHealth.maxHealth;
        _enemyHealth.OnHealthChanged += UpdateUI;

        _bossHealthBar.value = _enemyHealth.GetHealth();
    }

    private void UpdateUI(int healthChange)
    {
        _bossHealthBar.value = _enemyHealth.GetHealth();
    }
}
