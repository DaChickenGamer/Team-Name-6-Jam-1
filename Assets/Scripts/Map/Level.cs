using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Room> rooms;
    private Room _currentRoom;

    private void Start()
    {
        foreach (Room room in rooms)
        {
            room.OnEnterRoom += () => _currentRoom = room;
        } 
    }
}
