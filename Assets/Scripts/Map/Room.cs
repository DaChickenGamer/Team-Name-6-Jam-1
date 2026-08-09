using System;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Action OnEnterRoom;
    
    public List<Gate> Gates;

    private void Start()
    {
        foreach (Gate g in Gates)
        {
            g.GateExited += (player) => OnEnterRoom?.Invoke();
        }
    }
}
