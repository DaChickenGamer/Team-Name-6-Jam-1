using System;
using UnityEngine;
using DG.Tweening;


public class FloatlyImage : MonoBehaviour
{
    public float floatDistance = .5f;
    public float duration = 2.0f;
    
    private void Start()
    {
       transform.DOLocalMoveY(transform.localPosition.y - floatDistance, duration)
           .SetEase(Ease.InOutSine)
           .SetLoops(-1, LoopType.Yoyo); 
    }
}
