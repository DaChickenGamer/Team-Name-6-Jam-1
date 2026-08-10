using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject healthBar;
    public List<Image> heartContainer;
    
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void RedrawUI(int hearts, int maxHearts)
    {
        foreach (var heart in heartContainer)
        {
            Destroy(heart.gameObject);
        }
        
        heartContainer.Clear();
        
        for (int i = 0; i < maxHearts; i++)
        {
            GameObject heartInstance = Instantiate(healthBar, transform);
            Image heartImage = heartInstance.GetComponent<Image>();
            heartImage.sprite = i < hearts ? fullHeart : emptyHeart;
            heartContainer.Add(heartImage);
        }
    }
}
