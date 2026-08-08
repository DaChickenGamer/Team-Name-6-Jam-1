using UnityEngine;

public class ProjectileShockCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // shock player
            PlayerHealth healthScript = other.GetComponentInParent<PlayerHealth>();
            healthScript.RemoveHealth(1);
            Destroy(gameObject);
        }
        /*if(other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
    }

}
