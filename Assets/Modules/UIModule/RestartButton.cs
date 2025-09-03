using DG.Tweening;
using UnityEngine;

public class RestartButton : CallBackButton
{
    [SerializeField] private SpawnPoint _ShowPoint;
    [SerializeField] private SpawnPoint _HidePoint;
    
    public void ShowButton()
    {
        float duration = 0.5f;
        
        transform.DOLocalMove(_ShowPoint.transform.localPosition,duration);
    }

    public void HideButton()
    {
        float duration = 0.5f;
        
        transform.DOLocalMove(_HidePoint.transform.localPosition,duration);
    }
}
