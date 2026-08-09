using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject enemyToUse;

    public void Activate()
    {
        enemyToUse = Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    private void PositionEnemy()
    {
        enemyToUse.transform.position = transform.position;
        enemyToUse.transform.rotation = transform.rotation;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
