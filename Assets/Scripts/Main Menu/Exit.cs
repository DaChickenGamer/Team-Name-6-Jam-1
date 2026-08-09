using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    public void QuitGame ()
    {
        Debug.Log("Succesfully Quit!");
        Application.Quit();
    }
}
