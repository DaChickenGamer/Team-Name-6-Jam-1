using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "New Shell", menuName = "Data/Shell")]
public class ShellSO : ScriptableObject
{
    public List<ShellEffect> onHitEffects = new();
    
    public List<ShellEffect> onEquipEffects = new();
    public List<ShellEffect> onUnequipEffects = new();

    public ShellMoveEffect moveEffect;
    
    [Header("Art Assets")]
    public SpriteLibraryAsset shellAnimations;
    public Sprite shellSprite;
}
