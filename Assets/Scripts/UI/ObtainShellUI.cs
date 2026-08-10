using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObtainShellUI : MonoBehaviour
{
    public List<ShellSO> shellLoottable;
    public PickCardUI[] shellDisplays = new PickCardUI[3];

    public PlayerShell playerShell;
    
    private ShellSO[] shellsDropped = new ShellSO[3];

    public GameObject teleporter;
    public void DropShells()
    {
        playerShell.BreakShell();
        
        List<ShellSO> temp_shells = shellLoottable;

        for (int i = 0; i < shellsDropped.Length ; i++)
        {
            int random_shell = temp_shells.Count;
            
            shellsDropped[i] = temp_shells[Random.Range(0, random_shell)];
            temp_shells.Remove(shellsDropped[i]);

            shellDisplays[i].gameObject.SetActive(true);
            shellDisplays[i].ChangeShell(shellsDropped[i], this, i);
        }
    }

    public void CloseUI()
    {
        foreach (PickCardUI ui in shellDisplays)
        {
            ui.gameObject.SetActive(false);
        }
    }

    public void PickShell(int index)
    {
       
        playerShell.SwapShell(shellsDropped[index]);
        CloseUI();
        Instantiate(teleporter, FindAnyObjectByType<Level>().GetCurrentRoom().transform);
    }
}
