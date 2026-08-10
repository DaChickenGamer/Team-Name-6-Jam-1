using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public HealthUI healthUI;
    public GameObject deathScreen;
    
    private PlayerHealth _playerHealth;

    private void Start()
    {
       _playerHealth = GetComponentInParent<PlayerHealth>();
       _playerHealth.OnDeath += () =>
       {
           // REPLACE LATER
           EnemyStun[] enemyStuns = FindObjectsByType<EnemyStun>();
           foreach (var enemyStun in enemyStuns)
           {
               enemyStun.isStunned = true;
           }

           PlayerMovement playerMovement = _playerHealth.GetComponent<PlayerMovement>();
           playerMovement.stunDuration = 1000000000;

           ProjectileCollision[] projectileCollisions = FindObjectsByType<ProjectileCollision>();
           foreach (var projectileCollision in projectileCollisions)
           {
               Destroy(projectileCollision.gameObject);
           }

           Gate[] gates = FindObjectsOfType<Gate>();
           foreach (var gate in gates){
               Destroy(gate.gameObject);
           }


       deathScreen.SetActive(true);
       };
    }

    public void RetryLevelButton()
    {
        LevelManager levelManager = GameManager.Instance.LevelManager;
        
        print(levelManager.GetCurrentLevelName());

        MusicManager.Instance.PlayMusic("Level1");

        levelManager.LoadLevel(levelManager.GetCurrentLevelName());
    }

    public void BackToMenuButton()
    {
        LevelManager levelManager = GameManager.Instance.LevelManager;
        levelManager.LoadLevel(LevelName.MainMenu);
    }
    
}
