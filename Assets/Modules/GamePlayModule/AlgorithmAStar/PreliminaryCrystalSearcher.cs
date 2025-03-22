using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreliminaryCrystalSearcher 
{
    private StartField _startField;
    
    public Field Search(StartField startField)
    {
        _startField = startField;
        
        List<Field> untraveledFields = new List<Field>();
        List<Field> processedFields = new List<Field>();
        List<Field> traveledFields = new List<Field>();
        
        foreach (Connection connection in startField.ActiveConnections)
        {
            untraveledFields.Add(connection.ConnectionAnotherField.MotherField);
        }
        
        while (untraveledFields.Count > 0)
        {
            foreach (Field untraveledField in untraveledFields)
            {
                processedFields.Add(untraveledField);
            }
            
            untraveledFields.Clear();

            foreach (Field processedField in processedFields)
            {
                if (CheckCorrectCrystal(processedField))
                {
                    return processedField;
                }

                traveledFields.Add(processedField);
                
                foreach (Connection connection in processedField.ActiveConnections)
                {
                    CheckCorrectWay(connection,traveledFields,untraveledFields);
                }
            }
            
            processedFields.Clear();
        }
        
        return null;
    }

    private bool CheckCorrectCrystal(Field field)
    {
        if (CheckCrystalOnField(field))
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
