using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Wait", story: "Wait for [x] seconds", category: "Flow/Conditional", id: "739295a938ca8318f25712c6fe5b3d10")]
public partial class WaitAction : Action
{
    [SerializeReference] public BlackboardVariable<float> X;
    private float t;
    protected override Status OnStart()
    {
        t = 0;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(t >= X) return Status.Success;
        else {
            t += Time.deltaTime;
            return Status.Running;
        }
    }
}

