using System;
using UnityEngine;

public class EnableTimer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        TimerUI timerUI = other.GetComponentInChildren<TimerUI>();
        timerUI.EnableTimer();
    }
}
