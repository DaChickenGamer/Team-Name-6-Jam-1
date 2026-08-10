using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IRoomTrigger
{
    public GameObject enemyPrefab;
    private GameObject enemyToUse;

    //public void Activate()
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

    public void OnEnterRoom(Room room)
    {
        if (room.GetRoomCleared()) return;
        
        enemyToUse = Instantiate(enemyPrefab, transform.position, transform.rotation);
        enemyToUse.transform.SetParent(transform.parent);
        room.IncreaseEnemiesAlive();
        enemyToUse.GetComponent<EnemyHealth>().OnDeath += room.DecreaseEnemiesAlive;
    }
}
