using UnityEngine;

public class SharkEntry : MonoBehaviour
{
    [SerializeField] AudioClip roarClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundFXManager.Instance.PlaySoundFXClip(roarClip, transform, 0.2f);
    }
}
