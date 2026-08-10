using UnityEngine;

[CreateAssetMenu(fileName="Remove Cardboard Effect", menuName = "Data/Effects/Remove Cardboard Effect")]
public class RemoveCardboardEffect : ShellEffect
{
    public override void Trigger(Transform source = null)
    {
        var player = source != null && source.CompareTag("Player")
            ? source.gameObject
            : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;
        
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.ScaleSpeed(0.5f);

        PlayerDash dash = player.GetComponent<PlayerDash>();
        dash.canDash = true;
    }
}
