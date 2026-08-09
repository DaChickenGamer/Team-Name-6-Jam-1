using UnityEngine;

public class ProjectileShockCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // shock player here
            PlayerHealth healthScript = other.GetComponentInParent<PlayerHealth>();
            ProjectileProperties projProps = GetComponentInChildren<ProjectileProperties>();
            healthScript.RemoveHealth(projProps.damage);
            Destroy(gameObject);
        }
        if(!other.CompareTag("Projectile") && !other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
