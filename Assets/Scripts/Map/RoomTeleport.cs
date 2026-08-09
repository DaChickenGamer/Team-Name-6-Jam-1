using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Gate))]
public class RoomTeleport : MonoBehaviour
{
    private Gate _gate;
    private Vector3 teleportOffsetAmount;
    private int offset = 2;
    private GameObject camera;

    private void Start()
    {
        _gate = GetComponent<Gate>();
        
        _gate.GateEntered += Teleport;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Teleport(GameObject player)
    {
        if (!_gate.nextGate) return;

        teleportOffsetAmount = _gate.nextGate.transform.rotation.eulerAngles.z switch
        {
            90 => new Vector2(-offset, 0),
            180 => new Vector2(0, offset),
            270 => new Vector2(offset, 0),
            _ => new Vector2(0, offset)
        };

        player.transform.position = _gate.nextGate.transform.position + teleportOffsetAmount;

        Vector3 roomCoords = _gate.nextGate.transform.parent.transform.localPosition;
        camera.transform.position = new Vector3(roomCoords.x, roomCoords.y, camera.transform.position.z);
    }
}
