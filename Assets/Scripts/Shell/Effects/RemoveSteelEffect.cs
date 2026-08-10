using UnityEngine;

[CreateAssetMenu(fileName="Remove Steel Effect", menuName = "Data/Effects/Remove Steel Effect")]
public class RemoveSteelEffect : ShellEffect
{
    public int amountToRemove;
    
    public override void Trigger(Transform source = null)
    {
        var player = source != null && source.CompareTag("Player")
            ? source.gameObject
            : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (!playerHealth) return;

        playerHealth.RemoveMaxHealth(amountToRemove);
        
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.ScaleSpeed(2f);
    }
}