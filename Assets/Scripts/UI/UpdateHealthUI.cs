using UnityEngine;

public class UpdateHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public HealthUI healthUI;

    private void Awake()
    {
        playerHealth.OnHealthChanged += UpdateUI;
        playerHealth.OnMaxHealthChanged += UpdateUI;
    }

    private void Start()
    {
        healthUI.RedrawUI(playerHealth.GetCurrentHealth(), playerHealth.maxHealth);
    }

    private void UpdateUI(int throwAway)
    {
        healthUI.RedrawUI(playerHealth.GetCurrentHealth(), playerHealth.maxHealth);
    }
}
