using System;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endDisplayText;

    private bool doTimer = false;
    private float _startingTime;

    private void FixedUpdate()
    {
        if (!doTimer) return;
        _startingTime += Time.deltaTime;
        timerText.text = _startingTime.ToString("F2");
    }

    public void EnableTimer()
    {
        _startingTime = 0;
        timerText.gameObject.SetActive(true);
        doTimer = true;
    }

    public void StopTimer()
    {
        doTimer = false;
        timerText.gameObject.SetActive(false);
        endDisplayText.text = _startingTime.ToString("F2");
        endDisplayText.gameObject.SetActive(true);
    }

    public bool HasTimer()
    {
        return doTimer;
    }
}
