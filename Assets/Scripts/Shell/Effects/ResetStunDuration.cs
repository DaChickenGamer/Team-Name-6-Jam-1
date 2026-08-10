using UnityEngine;

[CreateAssetMenu(fileName="New Reset Stun Duration Effect", menuName = "Data/Effects/Rest Stun Duration Effect")]
public class ResetStunDuration : ShellEffect 
{
    public override void Trigger(Transform source = null, Transform hit = null)
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.ResetStunDuration();
    }
}
