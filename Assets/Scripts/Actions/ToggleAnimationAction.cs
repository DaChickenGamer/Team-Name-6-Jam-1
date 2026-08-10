using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Toggle Animation", story: "Toggle [Self] [animation] animation [bool]", category: "Action", id: "8a2c96de158ee9d105a141fdbe101221")]
public partial class ToggleAnimationAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<string> Animation;
    [SerializeReference] public BlackboardVariable<bool> Bool;

    private Animator _animator;
    
    protected override Status OnStart()
    {
        _animator = Self.Value.GetComponent<Animator>();
        _animator.SetBool(Animation.Value, Bool.Value);
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

