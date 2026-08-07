using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{ 
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
