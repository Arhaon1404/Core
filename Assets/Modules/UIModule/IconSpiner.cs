using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public class IconSpiner : MonoBehaviour
{
    [SerializeField] private Icon _icon;
    
    private Sequence _spinSequence;

    private void OnDisable()
    {
        ServiceLocator.GetService<LevelCompletionManager>().IsFirstStepComplited -= HideIcon;
    }

    private void Awake()
    {
        _spinSequence = DOTween.Sequence();

        float spinValue = 360;
        
        Vector3 target = new Vector3(_icon.transform.localPosition.x,_icon.transform.localPosition.y + spinValue, _icon.transform.localPosition.z);
        
        float duration = 4f;
        
        _spinSequence.Append(_icon.transform.DORotate(target,duration,RotateMode.WorldAxisAdd));
        _spinSequence.SetLoops(-1, LoopType.Restart);
    }

    public void Initialize()
    {
        ServiceLocator.GetService<LevelCompletionManager>().IsFirstStepComplited += HideIcon;
    }

    private void HideIcon()
    {
        ServiceLocator.GetService<LevelCompletionManager>().IsFirstStepComplited -= HideIcon;
        
        _spinSequence.Rewind();
        _spinSequence.Kill();
        
        Vector3 target = new Vector3(_icon.transform.position.x,_icon.transform.position.y + 20,_icon.transform.position.z);
        
        _icon.transform.DOLocalMove(target,1f);
    }
}
