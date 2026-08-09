using System;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject playerToUse;

    private void Start()
    {
        playerToUse = Instantiate(playerPrefab, transform.position, transform.rotation);
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