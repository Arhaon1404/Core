using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacklightSwitcher : MonoBehaviour
{
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private float _backlightDelay;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    
    private Outline _outline;
    
    private Coroutine _backlightTransitionCoroutine;
    private WaitForSeconds _backlightDelayWait;
    private bool _isCoroutineDone;
    private bool _isDone;
    
    private void Awake()
    { 
        _outline = GetComponent<Outline>();
        
        _backlightDelayWait = new WaitForSeconds(_backlightDelay);
    }

    public void TurnOn()
    {
        _isDone = false;

        _isCoroutineDone = true;
        
        InitiateCoroutine();
    }

    public void TurnOff()
    {
        if (_backlightTransitionCoroutine != null)
        {
            StopCoroutine(_backlightTransitionCoroutine);
            
            _backlightTransitionCoroutine = null;
        }
        
        _outline.OutlineWidth = 0;
        
        _outline.OutlineColor = _startColor;
        
        _isCoroutineDone = true;
        
        _isDone = true;
    }
    
    private void InitiateCoroutine()
    {
        if (_backlightTransitionCoroutine != null)
        {
            StopCoroutine(_backlightTransitionCoroutine);
        }

        if (_isCoroutineDone == true)
        {
            _isCoroutineDone = false;
            
            _backlightTransitionCoroutine = StartCoroutine(TransitBacklightCoroutine());
        }
    }
    
    private IEnumerator TransitBacklightCoroutine()
    {
        _outline.OutlineWidth = 0;
        
        _outline.OutlineColor = _startColor;

        float maxOutline = 30;
        
        float time = 0.0f;
        
        while (_isDone == false)
        {
            yield return null;
            
            if (_outline.OutlineWidth <= maxOutline)
            {
                float transitionStep = _transitionSpeed * Time.deltaTime;
            
                _outline.OutlineWidth += transitionStep;
                
                Color lerpedColor = Color.Lerp(_startColor, _endColor, time);
                
                time += 0.45f * Time.deltaTime;
                
                _outline.OutlineColor = lerpedColor;
            }
            else
            {
                yield return _backlightDelayWait;
                
                _outline.OutlineWidth = 0;
        
                time = 0.0f;
                
                _outline.OutlineColor = _startColor;
            }
        }
        
        _isCoroutineDone = true;
    }
}
