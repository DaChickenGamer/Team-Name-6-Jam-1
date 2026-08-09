using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        //assign
        audioSource.clip = audioClip;
        //volume
        audioSource.volume = volume;
        //play
        audioSource.Play();
        //get length
        float clipLength = audioSource.clip.length;
        //destroy
        Destroy(audioSource.gameObject, clipLength);
    }
}
