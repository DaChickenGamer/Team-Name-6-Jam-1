using Unity.Behavior;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth;
    public bool isBoss = false;
    public GameObject teleporter;
    private int health;
    public System.Action OnDeath;
    [SerializeField] AudioClip deathSoundClip;
    private SpriteRenderer renderer;
    private float deathTimer = 0;
    [SerializeField] private bool isTurtle;

    [SerializeField] AudioClip[] soundClips;
    int randNum;

    void Awake()
    {
        health = maxHealth;
        renderer = GetComponent<SpriteRenderer>();
    }
    public void RemoveHealth(int d)
    {
        print(health);
        if (health > 0) 
        {
            if (isTurtle)
            {
                randNum = Random.Range(0, 7);
                SoundFXManager.Instance.PlaySoundFXClip(soundClips[randNum], transform, 1f);
            }
            health -= d;
        }
        
        if(health <= 0)
        {
            OnDeath?.Invoke();
            SoundFXManager.Instance.PlaySoundFXClip(deathSoundClip, transform, 1f);
            deathTimer = 1;
            Destroy(GetComponent<Collider2D>());
            Destroy(GetComponent<BehaviorGraphAgent>());
        }
    }
    void Update()
    {
        if(deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
            if(deathTimer <= 0)
            {
                if(isBoss)
                {
                    if (GameManager.Instance.LevelManager.GetCurrentLevelNumber() >= 3)
                    {
                        TimerUI timerUI = FindAnyObjectByType<TimerUI>();
                        if (timerUI.HasTimer())
                            timerUI.StopTimer();
                        
                        ThanksForPlayingUI thanksForPlayingUI = FindAnyObjectByType<ThanksForPlayingUI>();
                        thanksForPlayingUI.ShowThanksText();
                    }
                    else
                        Instantiate(teleporter, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
            renderer.color = new Vector4(renderer.color.r, renderer.color.g, renderer.color.b, deathTimer);
        }
    }
}
