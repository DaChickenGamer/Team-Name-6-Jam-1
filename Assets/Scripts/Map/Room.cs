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

    private void Start()
    {
        foreach (Gate g in Gates)
        {
            g.GateExited += (player) => OnEnterRoom?.Invoke(this);
        }

        _roomTriggers = transform.GetComponentsInChildren<IRoomTrigger>();

        
        foreach (IRoomTrigger t in _roomTriggers)
        {
            OnEnterRoom += t.OnEnterRoom;
        }

        OnEnterRoom += (Room) => print(name);
    }

    public void IncreaseEnemiesAlive()
    {
        _enemiesAlive++;
    }

    public void DecreaseEnemiesAlive()
    {
        _enemiesAlive--;

        if (_enemiesAlive <= 0)
        {
            AllEnemiesDead?.Invoke();
        }
    }
}
