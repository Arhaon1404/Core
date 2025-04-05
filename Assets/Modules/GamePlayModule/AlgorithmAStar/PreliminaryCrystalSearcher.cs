using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreliminaryCrystalSearcher 
{
    private StartField _startField;

    private List<Field> _untraveledFields;
    private List<Field> _processedFields;
    private List<Field> _traveledFields;

    public PreliminaryCrystalSearcher()
    {
        _untraveledFields = new List<Field>();
        _processedFields = new List<Field>();
        _traveledFields = new List<Field>();
    }

    public Field Search(StartField startField)
    {
        _traveledFields.Clear();
        _processedFields.Clear();
        _untraveledFields.Clear();
        
        _startField = startField;
        
        foreach (Connection connection in startField.ActiveConnections)
        {
            Field proceedField = connection.ConnectionAnotherField.MotherField;

            if (CheckCrystalOnField(proceedField))
            {
                if (CheckCorrectCrystal(proceedField))
                {
                    return proceedField;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                _untraveledFields.Add(proceedField);
            }
        }
        
        while (_untraveledFields.Count > 0)
        {
            foreach (Field untraveledField in _untraveledFields)
            {
                _processedFields.Add(untraveledField);
            }
            
            _untraveledFields.Clear();

            foreach (Field processedField in _processedFields)
            {
                if (CheckCorrectCrystal(processedField) == true)
                {
                    return processedField;
                }
                
                _traveledFields.Add(processedField);
                
                foreach (Connection connection in processedField.ActiveConnections)
                {
                    CheckCorrectWay(connection,_traveledFields,_untraveledFields);
                }   
                
            }
            
            _processedFields.Clear();
        }
        
        return null;
    }

    private bool CheckCorrectCrystal(Field field)
    {
        if (CheckCrystalOnField(field))
            if(field.CrystalOnField.IsActiveCrystal == true)
                if(field.CrystalOnField.Color == _startField.CoreOnField.Color)
                    return true;
        
        return false;
    }

    private bool CheckCrystalOnField(Field field)
    {
        if(field.CrystalOnField)
            return true;
        
        return false;
    }


    private void CheckCorrectWay(Connection connection,List<Field> traveledFields, List<Field> untraveledFields)
    {
        bool isActiveConnectionLine = connection.ConnectionLine.isActiveAndEnabled;
        Field anotherField = connection.ConnectionAnotherField.MotherField;
        
        if (isActiveConnectionLine)
        {
            if (СomparisonСolor(connection, _startField))
            {
                if (CheckCrystalOnField(anotherField) == false)
                {
                    if (traveledFields.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                    {
                        untraveledFields.Add(connection.ConnectionAnotherField.MotherField);
                    }
                }
                else if (CheckCorrectCrystal(anotherField))
                {
                    if (traveledFields.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                    {
                        untraveledFields.Add(connection.ConnectionAnotherField.MotherField);
                    }
                }
            }
        }
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
