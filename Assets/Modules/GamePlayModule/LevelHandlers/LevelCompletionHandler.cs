using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionHandler
{
    public event Action VictoryСonfirmed;
    public event Action LoseСonfirmed;
    public event Action VictoryNotAchieved;
    
    public void CheckVictoryConditions(VictoryFieldStorage victoryFieldStorage)
    {
        StartField startField = victoryFieldStorage.StartField;
        List<Field> specialVictoryFields = victoryFieldStorage.SpecialFields;
        
        if (startField.listCores.Count == 0)
        {
            if (specialVictoryFields.Count == 0)
            {
                VictoryСonfirmed?.Invoke();
            }
            else
            {
                bool isWin = true;
                
                foreach (Field field in specialVictoryFields)
                {
                    if (!field.CrystalOnField)
                    {
                        isWin = false;
                        LoseСonfirmed.Invoke();
                    }
                    else
                    {
                        if (field.CrystalOnField.Color != field.Color)
                        {
                            isWin = false;
                            LoseСonfirmed.Invoke();
                        }
                    }
                }
                
                if (isWin)
                    VictoryСonfirmed?.Invoke();
            }
        }
        else
        {
            VictoryNotAchieved?.Invoke();
        }
    }
}
