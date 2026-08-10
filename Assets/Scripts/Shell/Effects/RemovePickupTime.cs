using UnityEngine;

[CreateAssetMenu(fileName="New Remove Pickup Time Effect", menuName = "Data/Effects/Remove Pickup Time Effect")]
public class RemovePickupTime : ShellEffect 
{
    public float timeToRemove;
    public override void Trigger(Transform source = null, Transform hit = null)
    {
        PlayerShell playerShell = FindObjectOfType<PlayerShell>();
        
        playerShell.RemovePickupDelay(timeToRemove);
        playerShell.ResetPickupTimer();
    }
}
