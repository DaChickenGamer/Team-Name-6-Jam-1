using System;
using UnityEngine;

public class Damage_Test : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.RemoveHealth(1);
        }
    }
}
