using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OrEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // hurt player
        }
        // add in enemy get hurt collision here
    }
}
