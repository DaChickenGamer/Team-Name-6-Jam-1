using UnityEngine;

public class ChangeMusic : MonoBehaviour, IRoomTrigger
{
public void OnEnterRoom(Room room)
    {
        MusicManager.Instance.PlayMusic("Level1Boss");
    }
}
