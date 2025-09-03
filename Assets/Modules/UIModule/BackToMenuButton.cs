using DG.Tweening;
using UnityEngine;

public class BackToMenuButton : CallBackButton
{
    [SerializeField] private SpawnPoint _HidePoint;
    
    public void HideButton()
    {
        float duration = 0.5f;
        
        transform.DOLocalMove(_HidePoint.transform.localPosition,duration);
    }
}
