using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "chargeup", story: "[Self] plays [soundeffect]", category: "Action", id: "30f2bee95b8259d517b02305e3a4d6eb")]
public partial class ChargeupAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<AudioClip> Soundeffect;

    protected override Status OnStart()
    {
        SoundFXManager.Instance.PlaySoundFXClip(Soundeffect, Self.Value.transform, 0.4f);
        return Status.Success;
    }
}

