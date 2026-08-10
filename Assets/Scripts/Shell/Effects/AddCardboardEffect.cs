using UnityEngine;

[CreateAssetMenu(fileName="Add Cardboard Effect", menuName = "Data/Effects/Add Cardboard Effect")]
public class AddCardboardEffect : ShellEffect
{
    public override void Trigger(Transform source = null)
    {
        var player = source != null && source.CompareTag("Player")
            ? source.gameObject
            : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;
        
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.ScaleSpeed(2f);

        PlayerDash dash = player.GetComponent<PlayerDash>();
        dash.canDash = false;
    }
}
