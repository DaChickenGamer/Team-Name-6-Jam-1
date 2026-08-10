using System;
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
   private Level _currentLevel;

   private void Start()
   {
      _currentLevel = FindAnyObjectByType<Level>();
   }

   public void LoadLevel(LevelName level)
   {
      SceneManager.LoadScene((int)level);
   }

   public Level GetCurrentLevel()
   {
      return _currentLevel;
   }
}
