using System;
using UnityEngine;

public class LevelTeleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        GameManager.Instance.LevelManager.NextLevel();
    }
}
