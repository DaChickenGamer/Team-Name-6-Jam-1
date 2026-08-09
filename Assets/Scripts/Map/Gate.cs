using System;
using Unity.VisualScripting;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Action<GameObject> GateEntered;
    public Action<GameObject> GateExited;

    public Gate nextGate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        GateEntered?.Invoke(other.gameObject);

        if (!nextGate) return;
        
        nextGate.GateExited?.Invoke(other.gameObject);
    }
}
