using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Outline))]

public class OutlineSwicher : MonoBehaviour
{
    [SerializeField] private Crystal _currentCrystal;
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private float _minOulineWidth;
    [SerializeField] private float _maxOulineWidth;
    [SerializeField] private Color _outlineColor;
    private Outline _outline;
    
    private Coroutine _outlineTransitionCoroutine;
    private bool _isCoroutineDone = true;
    private bool _isDone;
    
    public event Action OnActived;
    public event Action OnDeactivated;
    
    private void Awake()
    { 
        _outline = GetComponent<Outline>();
    }

    public void TurnOn()
    {
        OnActived?.Invoke();
        
        _isDone = false;
        
        InitiateCoroutine();
    }

    public void TurnOff()
    {
        _isDone = true;
        
        OnDeactivated?.Invoke();
    }
    
    private void InitiateCoroutine()
    {
        if (_outlineTransitionCoroutine != null)
        {
            StopCoroutine(_outlineTransitionCoroutine);
        }

        if (_isCoroutineDone == true)
        {
            _isCoroutineDone = false;
            
            _outlineTransitionCoroutine = StartCoroutine(TransitOutlineCoroutine());
        }
    }
    
    private IEnumerator TransitOutlineCoroutine()
    {
        _outline.OutlineWidth = _minOulineWidth;
        
        _outline.OutlineColor = _outlineColor;
        
        bool direction = true;
        
        while (_isDone == false)
        {
            yield return null;
            
            float transitionStep = _transitionSpeed * Time.deltaTime;

            if (direction)
            {
                if (_outline.OutlineWidth <= _maxOulineWidth)
                {
                    _outline.OutlineWidth += transitionStep;
                }
                else
                {
                    direction = false;
                }
            }
            else
            {
                if (_outline.OutlineWidth >= _minOulineWidth)
                {
                    _outline.OutlineWidth -= transitionStep;
                }
                else
                {
                    direction = true;
                }
            }
            
            _isCoroutineDone = true;
        }
    }
}
