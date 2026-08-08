using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEditor.UI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoot", story: "Shoot [projectile] at speed [speed] from [self] to [player] for [damage] damage", category: "Action", id: "f15dbb84f643de9b958775943ff4d7d9")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Projectile;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<int> Damage;
    protected override Status OnStart()
    {
        GameObject proj = GameObject.Instantiate(Projectile.Value, Self.Value.transform.position, Self.Value.transform.rotation);
        ProjectileProperties projProps = proj.GetComponent<ProjectileProperties>();
        projProps.damage = Damage;
        LinearShoot shootScript = proj.GetComponent<LinearShoot>();
        shootScript.Shoot(Player.Value.transform.position.x - Self.Value.transform.position.x, Player.Value.transform.position.y - Self.Value.transform.position.y, Speed);
        return Status.Success;
    }
}

