using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject playerToUse;

    private void Start()
    {
        playerToUse = Instantiate(playerPrefab, transform.position, transform.rotation);
    }

    private void PositionPlayer()
    {
        playerToUse.transform.position = transform.position;
        playerToUse.transform.rotation = transform.rotation;
    }
}