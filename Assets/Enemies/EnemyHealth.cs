using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth;
    private int health;
    void Awake()
    {
        health = maxHealth;
    }
    public void RemoveHealth(int d)
    {
        if(health > 0) health -= d;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
