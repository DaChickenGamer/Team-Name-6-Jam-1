using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveTowardsMovingTarget", story: "Move [self] towards [player] at speed [speed]", category: "Action", id: "fb215ec75d453b77b274a7f17e0535f3")]
public partial class MoveTowardsMovingTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<float> Speed;
    private Rigidbody2D rb;

    protected override Status OnStart()
    {
        rb = Self.Value.GetComponent<Rigidbody2D>();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector2 dir = new Vector2(Player.Value.transform.position.x - Self.Value.transform.position.x, Player.Value.transform.position.y - Self.Value.transform.position.y);
        rb.linearVelocity = dir.normalized * Speed;
        return Status.Running;
    }

}

