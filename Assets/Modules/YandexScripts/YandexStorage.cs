using System;
using UnityEngine;

namespace YG
{
    
    public partial class SavesYG
    {
        public int CurrentLevel;
        public int[] LevelADVViewStorage;
        public int[] LevelPointsStorage;
        
        public void SetNewRecordLeaderbord(int level, int points)
        {
            if (LevelPointsStorage.Length == 0 || LevelADVViewStorage.Length == 0)
            {
                CreateNewStoragePoints();
                CreateNewStorageADV();
            }

            if (LevelPointsStorage[level - 1] < points)
            {
                LevelPointsStorage[level - 1] = points;
            }
            
            int finalPointsCount = 0;
            
            for (int i = 0; i < LevelPointsStorage.Length; i++)
            {
                finalPointsCount += LevelPointsStorage[i];
            }
            
            YG2.SetLeaderboard("PointsLeaderboard", finalPointsCount);
        }

        public void SetADVView(int level)
        {
            LevelADVViewStorage[level - 1] = 1;
        }

        public int GetCurrentPlayerScore()
        {
            if (LevelPointsStorage == null)
            {
                CreateNewStoragePoints();
            }
            
            int playerScore = 0;
            
            for (int i = 0; i < LevelPointsStorage.Length; i++)
            {
                playerScore += LevelPointsStorage[i];
            }
            
            return playerScore;
        }
        
        public bool IsNewRecord(int level,int finaleLevelScore)
        {
            int ADVMultiplication = 2;
            
            if (LevelADVViewStorage == null)
            {
                CreateNewStorageADV();
            }
            
            if (LevelADVViewStorage[level - 1] == 1)
            {
                if ((finaleLevelScore * ADVMultiplication) > LevelPointsStorage[level - 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((finaleLevelScore) > LevelPointsStorage[level - 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int GetCurrentLevelScore(int level)
        {
            return LevelPointsStorage[level - 1];
        }

        private void CreateNewStoragePoints()
        {
            LevelPointsStorage = new int[50];
        }
        
        private void CreateNewStorageADV()
        {
            LevelADVViewStorage = new int[50];
        }
    }
}



