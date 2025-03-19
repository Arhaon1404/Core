using System;
using UnityEngine;

public class FieldNode : MonoBehaviour
{
    [SerializeField] private int _weightNode;
    [SerializeField] private int _wastedEnergy;
    [SerializeField] private Field _previousField;
    [SerializeField] private int _heuristicDistance;
    public int WeightNode => _weightNode;
    
    public int WastedEnergy => _wastedEnergy;
    public Field PreviousField => _previousField;
    
    public int HeuristicDistance => _heuristicDistance;
    
    public void SetWeightNode(int heuristicDistance)
    {
        if(heuristicDistance < 0)
            throw new ArgumentException("Invalid heuristicDistance");
        
        _heuristicDistance = heuristicDistance;
        _weightNode = heuristicDistance + _wastedEnergy;
    }

    public void SetWastedEnergy(int wastedEnergy)
    {
        if(wastedEnergy < 0)
            throw new ArgumentException("Invalid weight node");
        
        _wastedEnergy = wastedEnergy;
    }

    public void SetPreviousField(Field field)
    {
        if(_previousField == null)
            _previousField = field;
    }
}
