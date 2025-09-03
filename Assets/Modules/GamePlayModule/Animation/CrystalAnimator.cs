using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class CrystalAnimator : MonoBehaviour
{
    [SerializeField] private float _heightDiference;
    [SerializeField] private float _maxSpeedUpAndDown;
    [SerializeField] private float _minSpeedUpAndDown;
    [SerializeField] private float _maxSpeedRotating;
    [SerializeField] private float _minSpeedRotating;
    [SerializeField] private bool _isPlaying;

    private Sequence movingUpAndDownSequence;
    
    private void Awake()
    {
        CreateDotweenAnimation();
    }

    public void TurnOnUpAndDownAnimation()
    {
        if (_isPlaying)
        {
            movingUpAndDownSequence.Restart();
        }
    }

    public void TurnOffUpAndDownAnimation()
    {
        if (_isPlaying)
        {
            movingUpAndDownSequence.Pause();
        }
    }

    private void CreateDotweenAnimation()
    {
        movingUpAndDownSequence = DOTween.Sequence();
        
        if (_isPlaying)
        {
            float randomRotatingSpeed = Random.Range(_minSpeedRotating, _maxSpeedRotating);
            float randomUpAndDownSpeed = Random.Range(_minSpeedUpAndDown, _maxSpeedUpAndDown);
            
            Vector3 targetRotate = TakeRandomDirection();

            transform.DOLocalRotate(targetRotate, randomRotatingSpeed,RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Yoyo);
            
            //movingUpAndDownSequence.Append(transform.DOLocalMoveY(transform.localPosition.y + _heightDiference, randomUpAndDownSpeed));
            //movingUpAndDownSequence.Append(transform.DOLocalMoveY(transform.localPosition.y - _heightDiference, randomUpAndDownSpeed));
            //movingUpAndDownSequence.Append(transform.DOLocalMoveY(transform.localPosition.y, randomUpAndDownSpeed));
            //movingUpAndDownSequence.SetLoops(-1, LoopType.Yoyo);
        }
    }
    
    private Vector3 TakeRandomDirection()
    {
        float randomDirection = Random.Range(0f,1f);
        
        if (randomDirection <= 0.5f)
        {
            return new Vector3(0, 0, 360f);
        }
        else
        {
            return new Vector3(0, 0, -360f);
        }
    }
}
