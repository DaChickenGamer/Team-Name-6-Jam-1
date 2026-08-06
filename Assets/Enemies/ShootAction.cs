using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEditor.UI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoot", story: "Shoot [projectile] at [player] from [self]", category: "Action", id: "f15dbb84f643de9b958775943ff4d7d9")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Projectile;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    protected override Status OnStart()
    {
        GameObject proj = GameObject.Instantiate(Projectile, Self.transform.position, Self.transform.rotation);
        LinearShoot shoot_script = proj.GetComponent<LinearShoot>();
        shoot_script.Shoot(Player.transform.position.x, Player.transform.position.y);
        return Status.Success;
    }
}

