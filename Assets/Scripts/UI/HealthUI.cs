using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject healthBar;
    public List<Image> heartContainer;
    
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    public int lastFilledHeartIndex;
    
    private void Start()
    {
        for (int i = 0; i < playerHealth.maxHealth; i++)
        {
            AddHeart();
        }
        
    }

    public void AddHeart()
    {
        GameObject HeartInstance = Instantiate(healthBar, this.transform);
        heartContainer.Add(HeartInstance.GetComponent<Image>());
        lastFilledHeartIndex++;
    }
    
    public void RemoveHeart()
    {
        heartContainer.RemoveAt(heartContainer.Count - 1);
        if (heartContainer.Count - 1 == lastFilledHeartIndex)
        {
            lastFilledHeartIndex--;
        }
    }

    public void FillHeart()
    {
        if (lastFilledHeartIndex >= heartContainer.Count) return;
        heartContainer[lastFilledHeartIndex].sprite = fullHeart;
        lastFilledHeartIndex++;
    }

    public void UnfillHeart()
    {
        if (lastFilledHeartIndex <= 0) return;
        lastFilledHeartIndex--;
        heartContainer[lastFilledHeartIndex].sprite = emptyHeart;
    }
}
