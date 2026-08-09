using System;
using UnityEngine;

public class UpdateHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public HealthUI healthUI;

    private void Start()
    {
        playerHealth.AddMaxHealthEvent += AddMaxHealth;
        playerHealth.AddHealthEvent += AddHealth;
        playerHealth.RemoveMaxHealthEvent += RemoveMaxHealth;
        playerHealth.RemoveHealthEvent += RemoveHealth;
    }
    
    private void AddMaxHealth(int newMaxHealth)
    {
        for (int i = 0; i < newMaxHealth; i++)
        {
            healthUI.AddHeart();
        }
    }

    private void AddHealth(int newHealth)
    {
        for (int i = 0; i < newHealth; i++)
        {
            healthUI.FillHeart();
        }
    }
    
    private void RemoveMaxHealth(int newMaxHealth)
    {
        for (int i = 0; i < newMaxHealth; i++)
        {
            healthUI.RemoveHeart();
        }
    }

    private void RemoveHealth(int newHealth)
    {
        for (int i = 0; i < newHealth; i++)
        {
            healthUI.UnfillHeart();
        }
    }
}
