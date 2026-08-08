using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public event Action OnDeath;
    public event Action<int> OnHealthChanged;

    
    private void Start()
    {
        currentHealth = maxHealth; 
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    private void SetHealth(int newAmount)
    {
        OnHealthChanged?.Invoke(newAmount);
        if(newAmount > maxHealth)
            currentHealth = maxHealth;
        else if (newAmount < 0)
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }
        else
            currentHealth = newAmount;
    }

    private void SetMaxHealth(int newAmount)
    {
        if (newAmount <= 0)
        {
            print("Max Health can't be less than 0!");
            return;
        }
        
        maxHealth = newAmount;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void AddMaxHealth(int amount)
    {
        SetMaxHealth(maxHealth + amount);
    }

    public void RemoveMaxHealth(int amount)
    {
        SetMaxHealth(maxHealth - amount);
    }
        
    public void AddHealth(int amount)
    {
        if (amount < 0) return;
        SetHealth(currentHealth + amount);
    }

    public void RemoveHealth(int amount)
    {
        if (amount < 0) return;
        SetHealth(currentHealth - amount);
    }
}