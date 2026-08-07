using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName="New Add Health Effect", menuName = "Data/Effects/Add Health Effect")]
public class AddMaxHealthEffect : ShellEffect
{
    public int amountToAdd;
    
    public override void Trigger(Transform source = null)
    {
        var player = source != null && source.CompareTag("Player") ? source.gameObject : GameObject.FindGameObjectWithTag("Player");
        
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.AddMaxHealth(amountToAdd);
    }
}
