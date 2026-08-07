using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // hurt player
            Destroy(gameObject);
        }
        /*if(other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
    }
}
