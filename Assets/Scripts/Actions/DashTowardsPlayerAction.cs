using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DashTowardsPlayer", story: "[Self] dashes towards [player] at speed [speed] for [duration] seconds", category: "Action", id: "028ff48c8bc4a1e60f25308724910fab")]
public partial class DashTowardsPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<float> Duration;
    private Rigidbody2D rb;
    private float t;

    protected override Status OnStart()
    {
        rb = Self.Value.GetComponent<Rigidbody2D>();
        Vector2 vel_dir = Player.Value.transform.position - Self.Value.transform.position;
        rb.linearVelocity = vel_dir.normalized * Speed;
        t = 0;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        t += Time.deltaTime;
        if(t > Duration) 
        {
            rb.linearVelocity = new Vector2(0f, 0f);
            return Status.Success;
        }
        return Status.Running;
    }
}

