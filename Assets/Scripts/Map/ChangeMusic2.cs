using UnityEngine;

public class ChangeMusic2 : MonoBehaviour
{
    public void Start()
    {
        MusicManager.Instance.PlayMusic("Level2");
    }
}
