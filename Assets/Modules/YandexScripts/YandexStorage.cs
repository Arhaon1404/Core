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
            if (LevelPointsStorage == null || LevelADVViewStorage == null)
            {
                CreateNewStorageData();
            }
            
            LevelPointsStorage[level - 1] = points;

            int finalPointsCount = 0;
            
            for (int i = 0; i < LevelPointsStorage.Length; i++)
            {
                finalPointsCount += LevelPointsStorage[i];
            }
            
            YG2.SetLeaderboard("ScoreLeaderboard", finalPointsCount);
        }

        public void SetADVView(int level)
        {
            LevelADVViewStorage[level - 1] = 1;
        }

        public int GetCurrentPlayerScore()
        {
            if (LevelPointsStorage == null || LevelADVViewStorage == null)
            {
                CreateNewStorageData();
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

        private void CreateNewStorageData()
        {
            LevelPointsStorage = new int[50];
            LevelADVViewStorage = new int[50];
        }
    }
}



