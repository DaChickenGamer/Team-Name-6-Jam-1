using UnityEngine;

[CreateAssetMenu(fileName="New Remove Health Effect", menuName = "Data/Effects/Remove Health Effect")]
public class RemoveMaxHealthEffect : ShellEffect 
{
    public int amountToRemove;
    
    public override void Trigger(Transform source = null, Transform hit = null)
    {
        var player = source != null && source.CompareTag("Player") ? source.gameObject : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;
        
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.RemoveMaxHealth(amountToRemove);
    }
}
