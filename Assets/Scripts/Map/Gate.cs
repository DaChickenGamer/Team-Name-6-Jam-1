using System;
using Unity.VisualScripting;
using UnityEngine;

public class Gate : MonoBehaviour, IRoomTrigger
{
    public Action<GameObject> GateEntered;
    public Action<GameObject> GateExited;

    public Gate nextGate;

    private bool _gateLocked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || _gateLocked) return;
        
        GateEntered?.Invoke(other.gameObject);

        if (!nextGate) return;
        
        nextGate.GateExited?.Invoke(other.gameObject);
    }

    private void LockGate()
    {
        // TEMP WAY OF SHOWING DISABLED
        gameObject.GetComponent<SpriteRenderer>().color = Color.darkGray;
        
        _gateLocked = true;
    }

    private void UnlockGate()
    {
        // TEMP WAY OF SHOWING ENABLED 
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        
        _gateLocked = false;
    }

    public void OnEnterRoom(Room room)
    {
        LockGate();
        room.AllEnemiesDead += UnlockGate;
    }
}
