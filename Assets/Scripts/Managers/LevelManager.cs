using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level
{
   MainMenu,
   LevelOne,
   LevelTwo,
   LevelThree,
}

public class LevelManager : MonoBehaviour
{
   public void LoadLevel(Level level)
   {
      SceneManager.LoadScene((int)level);
   }
}
