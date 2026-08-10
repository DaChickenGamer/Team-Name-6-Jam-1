using System;
using UnityEngine;

public class LevelTeleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        PlayerShell playerShell = FindObjectOfType<PlayerShell>();
        if (playerShell != null)
            playerShell.EquipShell();
                
        GameManager.Instance.LevelManager.NextLevel();
    }
}
