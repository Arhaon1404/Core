using DG.Tweening;
using UnityEngine;

public class NextLevelButton : CallBackButton
{
    [SerializeField] private FinalLevelInfo _finalLevelInfo;
    [SerializeField] private SpawnPoint _spawnPoint;
    
    public void MoveButton(int finaleLevelScore)
    {
        float duration = 0.5f;
        
        transform.DOLocalMove(_spawnPoint.transform.localPosition,duration);
            
        _finalLevelInfo.UpdateInfo(finaleLevelScore);
    }
}
