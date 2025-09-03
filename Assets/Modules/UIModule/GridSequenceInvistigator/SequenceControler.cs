using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SequenceControler : Spawner<SequenceMark>
{
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private InvestigatorSequence _prefabInvestigatorSequence;
    [SerializeField] private SpawnPoint _investigatorSpawnPoint;
    [SerializeField] private List<SequenceMark> _colorMarks;
    [SerializeField] private List<GridCell> _sequenceGrids;
    
    [SerializeField] private List<Core> _startFieldListInfo;
    private int _currentCountCore;
    private GridCell _currentCell;
    
    public void InitializeSequence(StartField startField)
    {
        base.Awake();
        
        foreach (Core core in startField.ListCores)
        {
            _startFieldListInfo.Add(core);
        }
        
        startField.IsCoreMoved += MoveCells;
        
        foreach (GridCell cell in _sequenceGrids)
        {
            _currentCell = cell;
            
            AddNewElement();
        }

        InvestigatorSequence investigator = Instantiate(_prefabInvestigatorSequence,_investigatorSpawnPoint.transform);
        
        investigator.transform.localPosition = Vector3.zero;
    }
    
    protected override SequenceMark CreateObject()
    {
        SequenceMark currentMark = Instantiate(Prefab, _currentCell.transform);

        _currentCell.SetMark(currentMark);
        
        return currentMark;
    }
    
    protected override void OnTakeFromPool(SequenceMark mark)
    {
        base.OnTakeFromPool(mark);
        
        _currentCell.SetMark(mark);
        
        mark.transform.SetParent(_currentCell.transform);
        
        mark.transform.localPosition = Vector3.zero;
    }
    
    protected override void OnReturnedToPool(SequenceMark mark)
    {
        base.OnReturnedToPool(mark);
    }

    private void AddNewElement()
    {
        if (_startFieldListInfo.Count != 0)
        {
            if (_currentCell.Mark == null)
            {
                Pool.Get();
                    
                int firstElementIndex = 0;
                
                SequenceMark neededMark = _colorMarks.Find(m => m.ColorType == _startFieldListInfo[firstElementIndex].Color);
                
                _currentCell.Mark.ChangeColor(neededMark.ColorType,neededMark.StartColor);
                
                _startFieldListInfo.RemoveAt(firstElementIndex);
            }
        }
    }

    private void MoveCells()
    {
        int firstIndex = 0;
        
        int lastIndex = _sequenceGrids.Count - 1;
        
        Pool.Release(_sequenceGrids[firstIndex].Mark);
        
        _sequenceGrids[firstIndex].ResetMark();

        GridCell currentEpmtyCell = null;
        
        foreach (GridCell gridCell in _sequenceGrids)
        {
            if (gridCell.Mark != null)
            {
                SequenceMark currentMark = gridCell.Mark;
                
                currentEpmtyCell.SetMark(gridCell.Mark);
                
                currentMark.transform.SetParent(currentEpmtyCell.transform);
                
                currentMark.transform.localPosition = Vector3.zero;
                
                gridCell.ResetMark();
                
                currentEpmtyCell = gridCell;
            }
            else
            {
                currentEpmtyCell = gridCell;
            }
        }
        
        _currentCell = _sequenceGrids[lastIndex];
        
        AddNewElement();
        
        float shiftX = 40;

        transform.localPosition = new Vector3((transform.localPosition.x + shiftX), transform.localPosition.y, transform.localPosition.z);
        
        Vector3 leftShift = new Vector3((transform.localPosition.x - shiftX), transform.localPosition.y, transform.localPosition.z);

        transform.DOLocalMove(leftShift, 0.5f);
    }
}
