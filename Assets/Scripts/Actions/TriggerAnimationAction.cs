using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Trigger Animation", story: "Trigger [Self] [animation] animation", category: "Action", id: "b232378b3697088c5935392961dbd795")]
public partial class TriggerAnimationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<string> Animation;
    
    private Animator _animator;
    
    protected override Status OnStart()
    {
        _animator = Self.Value.GetComponent<Animator>();
        _animator.SetTrigger(Animation.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

