using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ShootSpread", story: "Shoot spread of [projectile] at speed [speed] from [self] to [player] for [damage] damage", category: "Action", id: "b62cb8a85fdb6d53a643edf13a453fdf")]
public partial class ShootSpreadAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Projectile;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<int> Damage;
    protected override Status OnStart()
    {
        for(int i = -1; i < 2; i++)
        {
            GameObject proj = GameObject.Instantiate(Projectile.Value, Self.Value.transform.position, Self.Value.transform.rotation);
            ProjectileProperties projProps = proj.GetComponent<ProjectileProperties>();
            projProps.damage = Damage;
            LinearShoot shootScript = proj.GetComponent<LinearShoot>();
            Vector2 dir = new Vector2(Player.Value.transform.position.x - Self.Value.transform.position.x + (float)Math.Cos(3.14f * 0.5f * i), Player.Value.transform.position.y - Self.Value.transform.position.y + (float)Math.Sin(3.14f * 0.5f * i));
            dir = dir.normalized;
            shootScript.Shoot(dir.x, dir.y, Speed);
        }
        return Status.Success;
    }
}

