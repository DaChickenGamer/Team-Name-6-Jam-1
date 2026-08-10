using UnityEngine;

[CreateAssetMenu(fileName="New Life Steal Effect", menuName = "Data/Effects/Life Steal Effect")]
public class LifeStealEffect : ShellEffect 
{
    public int lifeStealAmount;
    public int hitsRequired;

    private int _currentHits;

    public override void Trigger(Transform source = null, Transform hit = null)
    {
        if (!hit || !hit.CompareTag("Enemy")) return;

        _currentHits++;

        if (_currentHits < hitsRequired) return;

        var player = source != null && source.CompareTag("Player")
            ? source.gameObject
            : GameObject.FindGameObjectWithTag("Player");

        if (!player) return;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (!playerHealth) return;

        playerHealth.AddHealth(lifeStealAmount);
        
        _currentHits = 0;
    }
}
