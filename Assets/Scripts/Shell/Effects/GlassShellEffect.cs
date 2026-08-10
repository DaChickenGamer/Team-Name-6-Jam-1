using UnityEngine;

[CreateAssetMenu(fileName="Glass Shell Effect", menuName = "Data/Effects/Glass Shell Effect")]
public class GlassShellEffect : ShellEffect
{
    public override void Trigger(Transform source = null)
    {
        var player = source != null && source.CompareTag("Player") ? source.gameObject : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;
        
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.isGlass = true;
        PlayerShell playerShell = player.GetComponent<PlayerShell>();
        playerShell.isGlass = true;
    }
}
