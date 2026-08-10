using UnityEngine;

public class ChangeMusic3Boss : MonoBehaviour, IRoomTrigger
{
    public void OnEnterRoom(Room room)
    {
        MusicManager.Instance.PlayMusic("Level3Boss");
    }
}

