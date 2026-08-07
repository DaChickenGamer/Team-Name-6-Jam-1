using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName="New Add Health Effect", menuName = "Data/Effects/Add Health Effect")]
public class AddMaxHealthEffect : ShellEffect
{
    public int amountToAdd;
    
    public override void Trigger()
    {
        // Very inefficent but it's a game jam
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.AddMaxHealth(amountToAdd);
        }
    }
}
