using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth;
    public bool isBoss = false;
    private int health;
    public Action OnDeath;
    [SerializeField] AudioClip deathSoundClip;
    private SpriteRenderer renderer;
    private float deathTimer = 0;
    [SerializeField] private bool isTurtle;

    [SerializeField] AudioClip[] soundClips;
    int randNum;

    void Awake()
    {
        health = maxHealth;
        renderer = GetComponent<SpriteRenderer>();
    }
    public void RemoveHealth(int d)
    {
        print(health);
        if (health > 0) 
        {
            if (isTurtle)
            {
                randNum = UnityEngine.Random.Range(0, 8);
                SoundFXManager.Instance.PlaySoundFXClip(soundClips[randNum], transform, 1f);
            }
            health -= d;
        }
        
        if(health <= 0)
        {
            OnDeath?.Invoke();
            SoundFXManager.Instance.PlaySoundFXClip(deathSoundClip, transform, 1f);
            deathTimer = 1;
        }
    }
    void Update()
    {
        if(deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
            if(deathTimer <= 0)
            {
                if(isBoss)
                {
                    // do on boss death stuff
                }
                Destroy(gameObject);
            }
            renderer.color = new Vector4(renderer.color.r, renderer.color.g, renderer.color.b, deathTimer);
        }
    }
}
