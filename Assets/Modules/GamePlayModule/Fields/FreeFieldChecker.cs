using System.Collections.Generic;
using UnityEngine;

public class FreeFieldChecker : MonoBehaviour
{
    public List<Field> GetListFreeField(Field startField)
    {
        List<Field> freeFields = new List<Field>();
        
        foreach (Connection connection in startField.ActiveConnections)
        {
            if (connection.ConnectionLine.isActiveAndEnabled == false)
                continue;

            if (connection.ConnectionLine.AisleColors.Count == 0)
            {
                if (connection.ConnectionAnotherField.MotherField.CrystalOnField == null)
                {
                    freeFields.Add(connection.ConnectionAnotherField.MotherField);
                }
            }
            else
            {
                bool isColorCorrect = CompareColor(connection.MotherField.CrystalOnField.Color,connection.ConnectionLine);

                if (isColorCorrect)
                {
                    if (connection.ConnectionAnotherField.MotherField.CrystalOnField == null)
                    {
                        freeFields.Add(connection.ConnectionAnotherField.MotherField);
                    }
                }
            }
        }
        
        return freeFields;
    }
    
    private bool CompareColor(ColorType crystalColor,ConnectionLine connectionLine)
    {
        foreach (ColorType color in connectionLine.AisleColors)
        {
            if (crystalColor == color)
                return true;
        }
        
        return false;
    }
}
