using UnityEngine;

[CreateAssetMenu(fileName="New Reset Pickup Time Delay Effect", menuName = "Data/Effects/Reset Pickup Time Delay Effect")]
public class ResetPickupTime : ShellEffect 
{
    public override void Trigger(Transform source = null, Transform hit = null)
    {
        PlayerShell playerShell = FindObjectOfType<PlayerShell>();
        
        playerShell.ResetPickupTimer();
        playerShell.ResetPickupDelay();
    }
}
