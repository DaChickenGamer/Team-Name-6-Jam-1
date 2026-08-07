using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shell", menuName = "Data/Shell")]
public class ShellSO : ScriptableObject
{
    public List<ShellEffect> onHitEffects = new();
    
    public List<ShellEffect> onEquipEffects = new();
    public List<ShellEffect> onUnequipEffects = new();

    public ShellMoveEffect moveEffect;
}
