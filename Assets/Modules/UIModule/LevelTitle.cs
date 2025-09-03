using DG.Tweening;
using UnityEngine;

public class LevelTitle : MonoBehaviour
{
    [SerializeField] private SpawnPoint _HidePoint;
    
    public void Hide()
    {
        float duration = 0.5f;
        
        transform.DOLocalMove(_HidePoint.transform.localPosition,duration);
    }
}
