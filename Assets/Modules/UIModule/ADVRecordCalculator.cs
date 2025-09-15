using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ADVRecordCalculator : MonoBehaviour
{
    public bool IsShowButton(int level,int finaleLevelPoints)
    {
        int ADVMultiplication = 2;
        int currentLevelRecord = YG2.saves.GetCurrentLevelScore(level);

        if ((finaleLevelPoints * ADVMultiplication) > currentLevelRecord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
