using UnityEngine;

[CreateAssetMenu(fileName="Remove Glass Shell Effect", menuName = "Data/Effects/Remove Glass Shell Effect")]
public class RemoveGlassShellEffect : ShellEffect
{
    public override void Trigger(Transform source = null)
    {
        var player = source != null && source.CompareTag("Player") ? source.gameObject : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;
        
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.isGlass = false;
        PlayerShell playerShell = player.GetComponent<PlayerShell>();
        playerShell.isGlass = false;
    }
}