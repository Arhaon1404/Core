using DG.Tweening;
using UnityEngine;

public class DownUIObjects : MonoBehaviour
{
    [SerializeField] private SpawnPoint _HidePoint;
    [SerializeField] private InvestigatorBox _investigatorBox;
    
    public void Hide()
    {
        float duration = 0.5f;
        
        transform.DOLocalMove(_HidePoint.transform.localPosition,duration);
        
        _investigatorBox.Hide();
    }
}
