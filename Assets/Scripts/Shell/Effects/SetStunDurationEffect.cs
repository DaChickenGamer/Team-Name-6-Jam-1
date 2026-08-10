using UnityEngine;

[CreateAssetMenu(fileName="New Stun Duration Effect", menuName = "Data/Effects/Set Stun Duration Effect")]
public class SetStunDurationEffect : ShellEffect 
{
    public float stunDuration;

    public override void Trigger(Transform source = null, Transform hit = null)
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.SetStunDuration(stunDuration);
    }
}
