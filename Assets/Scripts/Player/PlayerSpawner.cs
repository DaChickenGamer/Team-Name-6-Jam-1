using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject playerToUse;

    private void Start()
    {
         playerToUse = GameObject.FindGameObjectWithTag("Player");

        
        if(!playerToUse)
            playerToUse = Instantiate(playerPrefab, transform.position, transform.rotation);
        
        playerToUse.transform.position = transform.position;
        
        PlayerHealth playerHealth = playerToUse.GetComponent<PlayerHealth>();
        playerHealth.ResetHealth();
    }

    private void PositionPlayer()
    {
        playerToUse.transform.position = transform.position;
        playerToUse.transform.rotation = transform.rotation;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}