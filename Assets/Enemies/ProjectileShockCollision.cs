using UnityEngine;

public class ProjectileShockCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // hurt player
            // shock player
            Destroy(gameObject);
        }
        /*if(other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
    }

}
