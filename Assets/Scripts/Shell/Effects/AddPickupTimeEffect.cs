using UnityEngine;

[CreateAssetMenu(fileName="New Add Pickup Time Effect", menuName = "Data/Effects/Add Pickup Time Effect")]
public class AddPickupTimeEffect : ShellEffect
{
    public float timeToAdd;
    
    public override void Trigger(Transform source = null, Transform hit = null)
    {
        PlayerShell playerShell = FindObjectOfType<PlayerShell>();
        
        playerShell.AddPickupDelay(timeToAdd);
        playerShell.ResetPickupTimer();
    }
}
