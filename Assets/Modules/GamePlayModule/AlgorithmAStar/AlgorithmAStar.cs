using System;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmAStar
{
    private readonly HeuristicDistanceCalculator _heuristicDistanceCalculator;
    private readonly EnergyWastedCalculator _energyWastedCalculator;
    private List<Field> _open = new List<Field>();
    private List<Field> _closed = new List<Field>();
    
    public AlgorithmAStar()
    {
        _heuristicDistanceCalculator = new HeuristicDistanceCalculator();
        _energyWastedCalculator = new EnergyWastedCalculator();
    }

    public List<AbstractField> Launch(StartField startField, Field targetField)
    {
        _energyWastedCalculator.Calculate(startField);
        
        int heuristicDistance;
        
        foreach (Connection connection in startField.ActiveConnections)
        {
            Field proceedField = connection.ConnectionAnotherField.MotherField;

            heuristicDistance = _heuristicDistanceCalculator.Calculate(proceedField,targetField);
            
            proceedField.FieldNode.SetWeightNode(heuristicDistance);
            
            _open.Add(connection.ConnectionAnotherField.MotherField);
        }
        
        while (_open.Count > 0)
        {
            Field currentFieldWithMinWeight = GetFieldWithMinWeight();

            Debug.Log(currentFieldWithMinWeight);
            
            if (currentFieldWithMinWeight == targetField)
            {
                List<AbstractField> path = new List<AbstractField>();

                bool foundPath = false;

                while (!foundPath)
                {
                    if (currentFieldWithMinWeight.FieldNode.PreviousField != null)
                    {
                        path.Add(currentFieldWithMinWeight.FieldNode.PreviousField);
                        currentFieldWithMinWeight = currentFieldWithMinWeight.FieldNode.PreviousField;
                        //Debug.Log(currentFieldWithMinWeight);
                        //Debug.Log(currentFieldWithMinWeight.FieldNode.HeuristicDistance);
                    }
                    else
                    {
                        path.Add(startField);
                        return path;
                    }
                }
            }
            
            _open.Remove(currentFieldWithMinWeight);
            _closed.Add(currentFieldWithMinWeight);

            List<Connection> unclosedConnections = GetUnclosedConnections(currentFieldWithMinWeight);
            
            Debug.Log("_open:");
            
            foreach (Connection connection in unclosedConnections)
            {
                if (_open.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                {
                    Field currentProccedingField = connection.ConnectionAnotherField.MotherField;
                    
                    heuristicDistance = _heuristicDistanceCalculator.Calculate(currentProccedingField, targetField);
                    
                    currentProccedingField.FieldNode.SetWeightNode(heuristicDistance);
                    currentProccedingField.FieldNode.SetPreviousField(currentFieldWithMinWeight);
                    
                    Debug.Log(currentProccedingField);
                    
                    _open.Add(currentProccedingField);
                }
            }

            Debug.Log("_open members:");
            
            foreach (Field field in _open)
            {
                Debug.Log(field);
            }
            
        }

        Debug.Log("Im not found way");
        
        return null;
    }

    private Field GetFieldWithMinWeight()
    {
        Field fieldWithMinWeight = null;
        
        foreach (Field field in _open)
        {
            if(!fieldWithMinWeight)
                fieldWithMinWeight = field;
            
            if(fieldWithMinWeight.FieldNode.WeightNode > field.FieldNode.WeightNode)
                fieldWithMinWeight = field;
        }
        
        return fieldWithMinWeight;
    }


    private List<Connection> GetUnclosedConnections(Field currentField)
    {
        List<Connection> connections = new List<Connection>();

        foreach (Connection connection in currentField.ActiveConnections)
        {
            if(connection.ConnectionLine.isActiveAndEnabled)
                if(_closed.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                    connections.Add(connection);
        }
        
        return connections;
    }
}
