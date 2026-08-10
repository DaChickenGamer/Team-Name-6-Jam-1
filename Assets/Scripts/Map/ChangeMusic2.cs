using UnityEngine;

public class ChangeMusic2 : MonoBehaviour, IRoomTrigger
{
    public void OnEnterRoom(Room room)
    {
        MusicManager.Instance.PlayMusic("Level2");
    }
}
