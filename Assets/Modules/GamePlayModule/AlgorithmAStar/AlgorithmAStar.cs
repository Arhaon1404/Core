using System;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmAStar
{
    private readonly HeuristicDistanceCalculator _heuristicDistanceCalculator;
    private readonly EnergyWastedCalculator _energyWastedCalculator;
    private List<Field> _open;
    private List<Field> _closed;
    private StartField _startField;
    private Field _targetField;
    
    
    public AlgorithmAStar()
    {
        _heuristicDistanceCalculator = new HeuristicDistanceCalculator();
        _energyWastedCalculator = new EnergyWastedCalculator();
    }

    public List<AbstractField> Launch(StartField startField, Field targetField)
    {
        _open = new List<Field>();
        _closed = new List<Field>();
        _startField = startField;
        _targetField = targetField;
        
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
            
            if (currentFieldWithMinWeight == targetField)
            {
                List<AbstractField> path = new List<AbstractField>();

                path.Add(currentFieldWithMinWeight);
                
                bool foundPath = false;

                while (!foundPath)
                {
                    if (currentFieldWithMinWeight.FieldNode.PreviousField != null)
                    {
                        path.Add(currentFieldWithMinWeight.FieldNode.PreviousField);
                        currentFieldWithMinWeight = currentFieldWithMinWeight.FieldNode.PreviousField;
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
            
            foreach (Connection connection in unclosedConnections)
            {
                if (_open.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                {
                    Field currentProccedingField = connection.ConnectionAnotherField.MotherField;
                    
                    heuristicDistance = _heuristicDistanceCalculator.Calculate(currentProccedingField, targetField);
                    
                    currentProccedingField.FieldNode.SetWeightNode(heuristicDistance);
                    currentProccedingField.FieldNode.SetPreviousField(currentFieldWithMinWeight);
                    
                    _open.Add(currentProccedingField);
                }
            }
        }
        
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
                if(CheckCorrectCrystal(connection))
                    if(СomparisonСolor(connection,_startField))
                        if(_closed.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                            connections.Add(connection);
        }
        
        return connections;
    }
    
    private bool CheckCorrectCrystal(Connection connection)
    {
        Crystal crystalOnField = connection.ConnectionAnotherField.MotherField.CrystalOnField;

        if (crystalOnField)
        {
            if(crystalOnField == _targetField.CrystalOnField)
                return true;
        }
        else
        {
            return true;
        }
        
        return false;
    }
    
    private bool СomparisonСolor(Connection connect, StartField startField)
    {
        if (connect.ConnectionLine.AisleColors.Count == 0)
        {
            return true;
        }
        else
        {
            ColorType crystalColor = startField.CoreOnField.Color;
            
            if (connect.ConnectionLine.AisleColors.IndexOf(crystalColor) != -1)
            {
                return true;
            }
        }
        
        return false;
    }
}
