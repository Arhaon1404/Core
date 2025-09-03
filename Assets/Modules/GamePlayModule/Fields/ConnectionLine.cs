using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshRenderer))]

public class ConnectionLine : MonoBehaviour
{
    [SerializeField] private List<ColorType> _aisleСolors = new List<ColorType>();
    [SerializeField] private float _maxAlphaBlink;
    [SerializeField] private float _minAlphaBlink;
    [SerializeField] private float _blinkspeed;
    [SerializeField] private Material _currentMaterial;
    [SerializeField] private Material _blinkMaterial;
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
        Material[] bufferMaterial = _meshRenderer.materials;

        bufferMaterial[0] = _blinkMaterial;
        
        _meshRenderer.materials = bufferMaterial;
        
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
        Material[] bufferMaterial = _meshRenderer.materials;

        bufferMaterial[0] = _currentMaterial;
        
        _meshRenderer.materials = bufferMaterial;
        
        _blinkingSequence.Pause();
        
        _meshRenderer.material.color = _originalColor;
    }

    private void SetupSequence()
    {
        Color firstTargetColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b,_maxAlphaBlink);
        Color secondTargetColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b,_minAlphaBlink);
        
        _blinkingSequence.Append(_blinkMaterial.DOColor(firstTargetColor, _blinkspeed));
        _blinkingSequence.Append(_blinkMaterial.DOColor(secondTargetColor, _blinkspeed));
        _blinkingSequence.SetLoops(-1, LoopType.Yoyo);

        _blinkingSequence.Pause();
    }
}
