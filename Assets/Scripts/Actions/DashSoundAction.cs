using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dash Sound", story: "[Self] plays [soundClip]", category: "Action", id: "271539e73d49ae02ac52827c982d44f7")]
public partial class DashSoundAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<AudioClip> SoundClip;

    protected override Status OnStart()
    {
        SoundFXManager.Instance.PlaySoundFXClip(SoundClip, Self.Value.transform, 1f);
        return Status.Success;
    }
}

