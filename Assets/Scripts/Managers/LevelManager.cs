using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelName
{
   MainMenu,
   LevelOne,
   LevelTwo,
   LevelThree,
}

public class LevelManager : MonoBehaviour
{
   public List<Level> levels;
   
   public void LoadLevel(LevelName level)
   {
      SceneManager.LoadScene((int)level);
   }
}
