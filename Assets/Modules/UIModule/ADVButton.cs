using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ADVButton : CallBackButton
{
    [SerializeField] private Color _currentColor;
    [SerializeField] private Color _deactivatedColor;
    [SerializeField] private Button _currentButton;
    [SerializeField] private Image _outline;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _iconADV;
    
    private Sequence _sequence;
    private Vector3 _startValue;
    
    public void ActivateButton()
    {
        _sequence = DOTween.Sequence();

        float duration = 1.5f;
        _startValue = transform.localScale;
        float endValue = 0.23f;
        
        _sequence.Append(transform.DOScale(endValue, duration));
        _sequence.Append(transform.DOScale(_startValue, duration));
        _sequence.SetLoops(-1, LoopType.Restart);
    }

    public void DeactivateButton()
    {
        if (_sequence != null)
        {
            _sequence.Kill();
            transform.localScale = _startValue;
        }
        
        _currentButton.enabled = false;
        ColorBlock colorButton = _currentButton.colors;
        
        colorButton.normalColor = _deactivatedColor;
        
        _currentButton.colors = colorButton;
        
        _outline.color = _deactivatedColor;
        _icon.color = _deactivatedColor;
        _iconADV.color = _deactivatedColor;
    }
}
