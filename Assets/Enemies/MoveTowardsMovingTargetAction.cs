using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveTowardsMovingTarget", story: "Move [self] towards player at speed [speed]", category: "Action", id: "fb215ec75d453b77b274a7f17e0535f3")]
public partial class MoveTowardsMovingTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> Speed;
    private Rigidbody2D rb;
    private GameObject Target;

    protected override Status OnStart()
    {
        rb = Self.Value.GetComponent<Rigidbody2D>();
        Target = GameObject.FindWithTag("Player");
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector2 dir = new Vector2(Target.transform.position.x - Self.Value.transform.position.x, Target.transform.position.y - Self.Value.transform.position.y);
        rb.linearVelocity = dir.normalized * Speed;
        return Status.Running;
    }

}

