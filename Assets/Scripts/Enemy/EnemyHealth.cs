using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth;
    private int health;
    public Action OnDeath;
    [SerializeField] AudioClip deathSoundClip;
    void Awake()
    {
        health = maxHealth;
    }
    public void RemoveHealth(int d)
    {
        print(health);
        if(health > 0) health -= d;
        if(health <= 0)
        {
            OnDeath?.Invoke();
            SoundFXManager.Instance.PlaySoundFXClip(deathSoundClip, transform, 1f);
            Destroy(gameObject);
        }
    }
}
