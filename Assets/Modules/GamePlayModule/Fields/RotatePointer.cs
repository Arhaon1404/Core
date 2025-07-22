using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class RotatePointer : MonoBehaviour
{
    [SerializeField] private float _maxAlphaBlink;
    [SerializeField] private float _minAlphaBlink;
    [SerializeField] private float _blinkspeed;
    private MeshRenderer _meshRenderer;

    private Color _originalColor;
    private Sequence _blinkingSequence;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _blinkingSequence = DOTween.Sequence();
        _originalColor = _meshRenderer.material.color;

        SetupSequence();
    }
    
    public void StartBlinking()
    {
        _blinkingSequence.Restart();
    }

    public void StopBlinking()
    {
        _blinkingSequence.Pause();
        _meshRenderer.material.color = _originalColor;
    }

    private void SetupSequence()
    {
        Color firstTargetColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b,_maxAlphaBlink);
        Color secondTargetColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b,_minAlphaBlink);
        
        _blinkingSequence.Append(_meshRenderer.material.DOColor(firstTargetColor, _blinkspeed));
        _blinkingSequence.Append(_meshRenderer.material.DOColor(secondTargetColor, _blinkspeed));
        _blinkingSequence.SetLoops(-1, LoopType.Yoyo);

        _blinkingSequence.Pause();
    }
}
