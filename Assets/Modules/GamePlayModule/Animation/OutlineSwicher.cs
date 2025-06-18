using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]

public class OutlineSwicher : MonoBehaviour
{
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private float _minOulineWidth;
    [SerializeField] private float _maxOulineWidth;
    private Outline _outline;
    
    private Coroutine _outlineTransitionCoroutine;
    private bool _isCoroutineDone = true;
    
    private void Awake()
    { 
        _outline = GetComponent<Outline>();
            
        _outline.enabled = false;
    }

    public void TurnOn()
    {
        _outline.enabled = true;
        InitiateCoroutine();
    }

    public void TurnOff()
    {
        _outline.enabled = false;
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
        
        bool direction = true;
        
        while (_outline.enabled)
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
        }
        
        _isCoroutineDone = true;
    }
    
    
}
