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
            Debug.Log("StartField is not crystal");
            return null;
        }

        if (endField.CrystalOnField)
        {
            Debug.Log("Endfield Crystal block way");
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
                    Debug.Log("ConnectionLine is not enabled");
                    return null;
                }
                
                return connect;
            }
        }

        Debug.Log("startField not connected on endField");
            
        return null;
    }
}
    

