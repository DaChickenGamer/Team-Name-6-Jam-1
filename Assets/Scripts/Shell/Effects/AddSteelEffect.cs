using UnityEngine;

[CreateAssetMenu(fileName="Add Steel Effect", menuName = "Data/Effects/Add Steel Effect")]
public class AddSteelEffect : ShellEffect
{
    public override void Trigger(Transform source = null)
    {
        var player = source != null && source.CompareTag("Player")
            ? source.gameObject
            : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (!playerHealth) return;

        playerHealth.AddMaxHealth(2);
        
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.ScaleSpeed(0.5f);
    }
}
