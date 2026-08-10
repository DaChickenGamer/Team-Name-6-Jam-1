using UnityEngine;

public class ChangeMusic2Boss : MonoBehaviour, IRoomTrigger
{
    public void OnEnterRoom(Room room)
    {
        MusicManager.Instance.PlayMusic("Level2Boss");
    }
}

