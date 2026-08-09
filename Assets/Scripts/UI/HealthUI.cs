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
        if (heartContainer.Count == 0) return;

        int lastIndex = heartContainer.Count - 1;
        Image heart = heartContainer[lastIndex];
        heartContainer.RemoveAt(lastIndex);
        if (heart)
            Destroy(heart.gameObject);

        if (lastFilledHeartIndex > heartContainer.Count)
            lastFilledHeartIndex = heartContainer.Count;
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
