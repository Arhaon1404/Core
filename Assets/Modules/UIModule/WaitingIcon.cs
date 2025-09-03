using System;
using DG.Tweening;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class WaitingIcon : MonoBehaviour
{
    [SerializeField] private float _spinDuration;
    [SerializeField] private float _moveDuration;
    [SerializeField] private SpawnPoint _startPosition;
    [SerializeField] private SpawnPoint _endPosition;
    
    private Sequence _spinSequence;

    public event Action<bool> IsCoreMoving;
    
    public void RegistrationTween()
    {
        _spinSequence = DOTween.Sequence();
        
        Vector3 spinTarget = new Vector3(transform.rotation.x, transform.rotation.y, -360);
        
        _spinSequence.Append(transform.DOLocalRotate(spinTarget, _spinDuration,RotateMode.FastBeyond360));
        _spinSequence.SetLoops(-1, LoopType.Restart);
    }

    public void TurnOnAnimation()
    {
        _spinSequence.Pause();
        
        transform.parent.DOLocalMove(_endPosition.transform.localPosition,_moveDuration);
        
        _spinSequence.Restart();
        _spinSequence.Play();
        
        IsCoreMoving?.Invoke(true);
    }

    public void TurnOffAnimation()
    {
        _spinSequence.Restart();
        
        transform.parent.DOLocalMove(_startPosition.transform.localPosition,_moveDuration);
        
        _spinSequence.Pause();
        
        IsCoreMoving?.Invoke(false);
    }
}
