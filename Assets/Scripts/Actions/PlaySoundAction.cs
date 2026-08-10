using System;
using Unity.Behavior;
using Unity.Mathematics;
using Unity.Properties;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlaySound", story: "[Self] plays [soundClip]", category: "Action", id: "5ea53e54947c06117d34273abda0945b")]
public partial class PlaySoundAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<AudioClip> SoundClip;
    protected override Status OnStart()
    {
        SoundFXManager.Instance.PlaySoundFXClip(SoundClip, Self.Value.transform, 1f);
        return Status.Success;
    }
}

