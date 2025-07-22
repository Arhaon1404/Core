using DG.Tweening;
using UnityEngine;

public class CoreRotator : MonoBehaviour
{
    [SerializeField] private float rotationLeftSpeed;
    [SerializeField] private float rotationRightSpeed;

    private Sequence rotationSequence;
    
    private void Awake()
    {
        InitializeMove();
    }

    private void InitializeMove()
    {
        rotationSequence = DOTween.Sequence();
        
        if (rotationLeftSpeed > 0)
        {
            Vector3 rotationLeft = new Vector3(0, -540, 0);

            rotationSequence.Append(transform.DORotate(rotationLeft, rotationLeftSpeed));
            rotationSequence.Append(transform.DORotate(Vector3.zero, rotationLeftSpeed));
            rotationSequence.SetLoops(-1, LoopType.Yoyo);
        }

        if (rotationRightSpeed > 0)
        {
            Vector3 rotationRight = new Vector3(0, 540, 0);
            
            rotationSequence.Append(transform.DORotate(rotationRight, rotationRightSpeed));
            rotationSequence.Append(transform.DORotate(Vector3.zero, rotationRightSpeed));
            rotationSequence.SetLoops(-1, LoopType.Yoyo);
        }
    }
}
