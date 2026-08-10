using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName="New Tracking Effect", menuName = "Data/Effects/Tracking Effect")]
public class TrackEnemyEffect : ShellMoveEffect 
{
    public int trackingRadius = 5;
    
    public override Vector3 TriggerMove(Transform shellTransform)
    {
        Collider2D[] overlap = Physics2D.OverlapCircleAll(shellTransform.position, trackingRadius);
        
        GameObject closetEnemy = null;
        
        foreach (Collider2D collider in overlap)
        {
            if (!collider.CompareTag("Enemy")) continue;

            if (!closetEnemy || Vector2.Distance(shellTransform.position, collider.transform.position) < Vector2.Distance(shellTransform.position, closetEnemy.transform.position))
                closetEnemy = collider.gameObject;
        }

        // BUG: DO NOT USE GET COMPONENT IN THE FUTURE
        return closetEnemy ? Vector3.MoveTowards(shellTransform.position, closetEnemy.transform.position, 10 * Time.deltaTime) : Vector2.MoveTowards(shellTransform.position, shellTransform.position + new Vector3(shellTransform.GetComponent<PlayerShell>().GetThrowDir().x, shellTransform.GetComponent<PlayerShell>().GetThrowDir().y, 0), 10 * Time.deltaTime);
    }

    public override void Trigger(Transform source = null, Transform hit = null)
    {
       // Not needed in here for now 
    }
}
