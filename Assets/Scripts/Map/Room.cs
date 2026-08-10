using System;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Action<Room> OnEnterRoom;
    public Action AllEnemiesDead;
    
    public List<Gate> Gates;
    
    private IRoomTrigger[] _roomTriggers;

    private int _enemiesAlive = 0;
    private bool _roomCleared = false;

    private bool _hasEnemies = false;

    private PlayerShell shellScript;

    private Level currentLevel;


    private void Start()
    {
        foreach (Gate g in Gates)
        {
            g.GateExited += (player) => OnEnterRoom?.Invoke(this); 
        }

        _roomTriggers = transform.GetComponentsInChildren<IRoomTrigger>();
        _hasEnemies = transform.GetComponentsInChildren<EnemySpawner>().Length > 0;
        
        foreach (IRoomTrigger t in _roomTriggers)
        {
            OnEnterRoom += t.OnEnterRoom;
        }
        OnEnterRoom += ResetShell;
    }

    private void ResetShell(Room room)
    {
        shellScript = FindAnyObjectByType<PlayerShell>();
        shellScript.FixShellOutOfBounds(room);
    }

    public void IncreaseEnemiesAlive()
    {
        _enemiesAlive++;
    }

    public void DecreaseEnemiesAlive()
    {
        _enemiesAlive--;

        if (_enemiesAlive > 0) return;
        
        _roomCleared = true;
        AllEnemiesDead?.Invoke();
    }
    
    public bool GetRoomCleared()
    {
        return _roomCleared || !_hasEnemies;
    }

    private void OnDestroy()
    {
        OnEnterRoom -= ResetShell;
    }
}
