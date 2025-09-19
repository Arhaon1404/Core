using DG.Tweening;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    Sequence _sequence;
    
    public void PauseAnimation()
    {
        _sequence.Pause();
        
        transform.gameObject.SetActive(false);
    }

    public void PlayAnimation()
    {
        if (_sequence == null)
        {
            SetSequenceAnimation();
            _sequence.Play();
        }
        else
        {
            transform.gameObject.SetActive(true);
            
            _sequence.Restart();
            _sequence.Play();
        }
    }
    
    private void SetSequenceAnimation()
    {
        _sequence = DOTween.Sequence();

        Vector3 startPosition = transform.position;
        Vector3 newPosition = new Vector3(startPosition.x,startPosition.y - 0.5f,startPosition.z);
        
        _sequence.Append(transform.DOMove(newPosition, 2f));
        _sequence.Append(transform.DOMove(startPosition, 2f));
        _sequence.SetLoops(-1, LoopType.Restart);
    }
}
