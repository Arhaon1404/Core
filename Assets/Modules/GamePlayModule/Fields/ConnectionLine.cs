using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class ConnectionLine : MonoBehaviour
{
    [SerializeField] private List<ColorType> _aisleСolors = new List<ColorType>();
    [SerializeField] private float _maxAlphaBlink;
    [SerializeField] private float _minAlphaBlink;
    [SerializeField] private float _blinkspeed;
    private MeshRenderer _meshRenderer;

    private Color _originalColor;
    private Sequence _blinkingSequence;
    
    private bool _isSequenceInitialized;
    
    public List<ColorType> AisleColors => _aisleСolors;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _originalColor = _meshRenderer.material.color;

        _isSequenceInitialized = false;
    }
    
    public void TurnOff(ConnectionLine verifiableConnectionLine)
    {
        if(verifiableConnectionLine == this)
            gameObject.SetActive(false);
    }
    
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
    
    public void StartBlinking()
    {
        if (!_isSequenceInitialized)
        {
            _isSequenceInitialized = true;
            
            _blinkingSequence = DOTween.Sequence();
            
            SetupSequence();
        }
        
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
