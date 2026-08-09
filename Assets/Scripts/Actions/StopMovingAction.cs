using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StopMoving", story: "[Self] stops moving", category: "Action", id: "01b113a76800f45e31f6405216115807")]
public partial class StopMovingAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        Rigidbody2D rb = Self.Value.GetComponent<Rigidbody2D>();
        rb.linearVelocity *= 0;
        return Status.Success;
    }
}

