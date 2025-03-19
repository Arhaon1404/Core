using System.Collections.Generic;
using UnityEngine;

public class EnergyWastedCalculator
{
    public void Calculate(StartField startField)
    {
        List<Field> untraveledFields = new List<Field>();
        List<Field> processedFields = new List<Field>();
        List<Field> traveledFields = new List<Field>();
        
        foreach (Connection connection in startField.ActiveConnections)
        {
            untraveledFields.Add(connection.ConnectionAnotherField.MotherField);
        }

        int count = 1;
        
        while (untraveledFields.Count > 0)
        {
            foreach (Field untraveledField in untraveledFields)
            {
                processedFields.Add(untraveledField);
            }
            
            untraveledFields.Clear();

            foreach (Field processedField in processedFields)
            {
                processedField.FieldNode.SetWastedEnergy(count);
                
                traveledFields.Add(processedField);

                foreach (Connection connection in processedField.ActiveConnections)
                {
                    if (connection.ConnectionLine.isActiveAndEnabled)
                    {
                        if (traveledFields.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                        {
                            untraveledFields.Add(connection.ConnectionAnotherField.MotherField);
                        }
                    }
                }
            }
            
            processedFields.Clear();
            
            count++;
        }
    }
}
