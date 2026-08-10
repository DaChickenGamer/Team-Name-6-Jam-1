using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ShootRing", story: "Shoot ring of [projectile] at speed [speed] from [self] for damage [damage]", category: "Action", id: "c400f5dcacb680376c4a4247444cb3b5")]
public partial class ShootRingAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Projectile;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<int> Damage;
    protected override Status OnStart()
    {
        for(float i = 0; i < 8; i++)
        {
            GameObject proj = GameObject.Instantiate(Projectile.Value, Self.Value.transform.position, Self.Value.transform.rotation);
            ProjectileProperties projProps = proj.GetComponent<ProjectileProperties>();
            projProps.damage = Damage;
            LinearShoot shootScript = proj.GetComponent<LinearShoot>();
            shootScript.Shoot((float)Math.Cos(3.14f * 0.25f * i), (float)Math.Sin(3.14f * 0.25f * i), Speed);
        }
        return Status.Success;
    }
}

