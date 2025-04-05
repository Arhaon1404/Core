using System;
using UnityEngine;

public class FieldsHandler
{
    public Connection Process(Field startField,Field endField)
    {
        if(!startField)
            throw new ArgumentNullException(nameof(startField));
            
        if(!endField)
            throw new ArgumentNullException(nameof(endField));
        
        if (!startField.CrystalOnField)
        {
            return null;
        }

        if (startField.CrystalOnField.IsActiveCrystal == false)
        {
            return null;
        }

        if (endField.CrystalOnField)
        {
            return null;    
        }

        foreach (Connection connect in startField.ActiveConnections)
        {
            if (!connect)
                throw new ArgumentNullException(nameof(connect));
            
            Field verifiableField = connect.ConnectionAnotherField.MotherField;
            
            if (verifiableField == endField)
            {
                if (!connect.ConnectionLine.isActiveAndEnabled)
                {
                    return null;
                }

                if (!СomparisonСolor(connect,startField))
                {
                    return null;
                }
                
                return connect;
            }
        }
        
        return null;
    }

    private bool СomparisonСolor(Connection connect, Field startField)
    {
        if (connect.ConnectionLine.AisleColors.Count == 0)
        {
            return true;
        }
        else
        {
            ColorType crystalColor = startField.CrystalOnField.Color;
            
            if (connect.ConnectionLine.AisleColors.IndexOf(crystalColor) != -1)
            {
                return true;
            }
        }
        
        return false;
    }
}
    

