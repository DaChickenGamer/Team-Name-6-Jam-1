using System;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CostumeManager : MonoBehaviour
{
    private SpriteLibrary _spriteLibrary;
    public PlayerShell playerShell;

    public SpriteLibraryAsset defaultCostume;
    public SpriteLibraryAsset[] allCostumes;

    private void Awake()
    {
        _spriteLibrary = GetComponent<SpriteLibrary>();
        
        playerShell.EquipShellEvent += ChangeCostume;
        playerShell.UnequipShellEvent += ResetToDefault;
    }

    public void ResetToDefault()
    {
        _spriteLibrary.spriteLibraryAsset = defaultCostume;
    }

    public void ChangeCostume(ShellSO newShell)
    {
        _spriteLibrary.spriteLibraryAsset = newShell.shellAnimations;
    }
}
