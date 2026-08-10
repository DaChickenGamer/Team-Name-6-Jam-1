using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class UISFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _button;
    private bool _scaledButton = false;
    private void Start()
    {
        _button = GetComponent<Button>();
        //_button.onClick.AddListener(() => AudioManager.Instance.PlaySfxClip(1));
        _button.onClick.AddListener(ScaleButton);
    }

    private void ScaleButton()
    {
        if (_scaledButton) return;
        
        transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.25f, 1, 0.5f).OnComplete(() => _scaledButton = false);
        _scaledButton = true;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //AudioManager.Instance.PlaySfxClip(0);
        transform.DOScale(1.2f, .3f);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, .3f);
    }
}