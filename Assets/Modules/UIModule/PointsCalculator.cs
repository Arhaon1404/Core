using System;
using UnityEngine;

public class PointsCalculator : MonoBehaviour
{
    public int Calculate(LevelInfo levelInfo,int finaleCountSteps, int finaleCountSecond)
    {
        int minusAmount = 0;
        
        int pointsSteps = finaleCountSteps * levelInfo.deductedMovePoints;

        if (pointsSteps >= levelInfo.maxDeductedMovePoints)
        {
            pointsSteps = levelInfo.maxDeductedMovePoints;
            
            minusAmount += pointsSteps;
        }
        else
        {
            minusAmount += pointsSteps;
        }
        
        int convertedTime = Mathf.RoundToInt(finaleCountSecond / 10);
        
        int pointsSeconds = convertedTime * levelInfo.pointsDeductedTenSeconds;

        if (pointsSeconds >= levelInfo.maxPointsDeductedTenSeconds)
        {
            pointsSeconds = levelInfo.maxPointsDeductedTenSeconds;
            
            minusAmount += pointsSeconds;
        }
        else
        {
            minusAmount += pointsSeconds;
        }
        
        int finaleCountPoints = levelInfo.maxLevelPoints - minusAmount;
        
        return finaleCountPoints;
    }
}
