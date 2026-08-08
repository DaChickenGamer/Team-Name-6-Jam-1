using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int contactDamage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealth healthScript = other.GetComponentInParent<PlayerHealth>();
            healthScript.RemoveHealth(contactDamage);
        }
        // add in enemy get hurt collision here
    }
}
