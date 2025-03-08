using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalMover : MonoBehaviour
{
    [SerializeField] private float _interactionDistance;
    [SerializeField] private float _speed;
    
    private Coroutine _moveCoroutine;
    private bool _isCoroutineDone = true;

    public event Action TargetReached;
    
    public void Move(Vector3 wayPoint)
    {
        InitiateCoroutine(wayPoint);
    }
    
    private void InitiateCoroutine(Vector3 target)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        if (_isCoroutineDone == true)
        {
            _isCoroutineDone = false;
            
            _moveCoroutine = StartCoroutine(MoveCoroutine(target));
        }
    }
    
    private IEnumerator MoveCoroutine(Vector3 target)
    {
        bool _isMovingEnable = true;
        
        while (_isMovingEnable)
        {
            yield return null;
            
            float step = _speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target, step);

            float targetDistance = transform.position.SqrDistance(target);
            
            if (targetDistance < _interactionDistance)
            {
                _isMovingEnable = false;                
            }
        }
        
        _isCoroutineDone = true;
        
        TargetReached?.Invoke();
    }
}
