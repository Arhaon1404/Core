using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeuristicDistanceCalculator
{
    public int Calculate(Field startField, Field targetField)
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
                if(processedField == targetField)
                    return count;
                
                traveledFields.Add(processedField);

                foreach (Connection connection in processedField.ActiveConnections)
                {
                    if (traveledFields.IndexOf(connection.ConnectionAnotherField.MotherField) == -1)
                    {
                        untraveledFields.Add(connection.ConnectionAnotherField.MotherField);
                    }
                }
            }
            
            processedFields.Clear();
            
            count++;
        }

        return 0;
    }
}
