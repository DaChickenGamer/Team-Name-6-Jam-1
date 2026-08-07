using UnityEngine;

[CreateAssetMenu(fileName="New Remove Health Effect", menuName = "Data/Effects/Remove Health Effect")]
public class RemoveMaxHealthEffect : ShellEffect 
{
    public int amountToRemove;
    
    public override void Trigger()
    {
        // Very inefficent but it's a game jam
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.RemoveMaxHealth(amountToRemove);
        }
    }

}
