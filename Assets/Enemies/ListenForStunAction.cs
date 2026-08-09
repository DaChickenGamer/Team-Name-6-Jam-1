using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ListenForStun", story: "[Self] listens for stun", category: "Action", id: "fdc5d3b190a233d3c9abcb03788998bc")]
public partial class ListenForStunAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    private EnemyStun stunScript;
    protected override Status OnStart()
    {
        stunScript = Self.Value.GetComponent<EnemyStun>();
        stunScript.isStunned = false;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(stunScript.isStunned) return Status.Success;
        return Status.Running;
    }
}

