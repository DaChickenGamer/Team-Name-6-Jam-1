using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Room> rooms;
    private Room _currentRoom;

    public Action<Room> ChangedRoom;

    private void Start()
    {
        foreach (Room room in rooms)
        {
            room.OnEnterRoom += RoomEntered; 
        } 
    }
    
    private void RoomEntered(Room room)
    {
        _currentRoom = room;
        ChangedRoom?.Invoke(room);
    }
    
    public Room GetCurrentRoom()
    {
        return _currentRoom;
    }
}
