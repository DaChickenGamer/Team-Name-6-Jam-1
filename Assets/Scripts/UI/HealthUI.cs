using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject healthBar;
    public List<Image> heartContainer;
    
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
    }
    
    public void RemoveHeart()
    {
        heartContainer.RemoveAt(heartContainer.Count - 1);
    }
}
