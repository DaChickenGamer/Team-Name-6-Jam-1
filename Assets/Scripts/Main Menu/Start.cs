using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlayMusic("MainMenu");
    }
    public void PlayGame()
    {
        GameManager.Instance.LevelManager.LoadLevel(LevelName.LevelOne);
        MusicManager.Instance.PlayMusic("Level1");
    }
}
