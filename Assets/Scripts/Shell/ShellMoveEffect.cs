using UnityEngine;

public abstract class ShellMoveEffect : ShellEffect
{
    public abstract Vector3 TriggerMove(Transform shellTransform);
}
