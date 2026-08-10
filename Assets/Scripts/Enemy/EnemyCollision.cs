using System;
using Unity.Mathematics;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int contactDamage = 1;
    public bool isBouncy = false;
    private Rigidbody2D rb;
    [SerializeField] AudioClip attackSoundClip;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(isBouncy && !other.CompareTag("Projectile") && !other.CompareTag("Enemy"))
        {
            Vector2 contactNormal = other.ClosestPoint(transform.position) - new Vector2(transform.position.x, transform.position.y);
            if(Math.Abs(contactNormal.y) > 0)
            {
                rb.linearVelocity *= new Vector2(1,-1);
            }
            if(Math.Abs(contactNormal.x) > 0)
            {
                rb.linearVelocity *= new Vector2(-1,1);
            }
        }
        if(other.CompareTag("Player"))
        {
            PlayerHealth healthScript = other.GetComponentInParent<PlayerHealth>();
            SoundFXManager.Instance.PlaySoundFXClip(attackSoundClip, transform, 0.2f);
            healthScript.RemoveHealth(contactDamage);
        }
        else if(!isBouncy && !other.CompareTag("Projectile") && !other.CompareTag("Enemy"))
        {
            rb.linearVelocity *= 0;
        }
    }
}
