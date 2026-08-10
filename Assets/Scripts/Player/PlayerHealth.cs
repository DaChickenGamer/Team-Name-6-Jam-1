using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public float iFrameLength = 2;
    private float iFrameCount = 0;

    public event Action OnDeath;
    public event Action<int> OnHealthChanged;
    public event Action<int> OnMaxHealthChanged; 
    public event Action<int> AddMaxHealthEvent;
    public event Action<int> AddHealthEvent;
    public event Action<int> RemoveMaxHealthEvent;
    public event Action<int> RemoveHealthEvent;

    
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(iFrameCount >= 0)
        {
            iFrameCount -= Time.deltaTime;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    private void SetHealth(int newAmount)
    {
        if (newAmount > maxHealth)
            currentHealth = maxHealth;
        else if (newAmount < 0)
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }
        else
            currentHealth = newAmount;

        OnHealthChanged?.Invoke(currentHealth);
    }

    private void SetMaxHealth(int newAmount)
    {
        if (newAmount <= 0)
        {
            print("Max Health can't be less than 0!");
            return;
        }
        
        maxHealth = newAmount;
        OnMaxHealthChanged?.Invoke(newAmount);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void AddMaxHealth(int amount)
    {
        bool wasFull = currentHealth >= maxHealth;
        AddMaxHealthEvent?.Invoke(amount);
        SetHealth(currentHealth + amount);
        SetMaxHealth(maxHealth + amount);
        if (wasFull)
            AddHealth(amount);
    }

    public void RemoveMaxHealth(int amount)
    {
        RemoveMaxHealthEvent?.Invoke(amount);
        SetHealth(currentHealth - amount);
        SetMaxHealth(maxHealth - amount);
    }
        
    public void AddHealth(int amount)
    {
        AddHealthEvent?.Invoke(amount);
        if (amount < 0) return;
        SetHealth(currentHealth + amount);
    }

    public void RemoveHealth(int amount)
    {
        if(iFrameCount <= 0)
        {
            if (amount < 0) return;
            RemoveHealthEvent?.Invoke(amount);
            SetHealth(currentHealth - amount);
            iFrameCount = iFrameLength;
        }
    }
}