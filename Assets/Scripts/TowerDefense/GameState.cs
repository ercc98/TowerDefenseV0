using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Tower;
using TowerDefense.Data;

namespace TowerDefense
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private GameStateData gameStateData;
        [SerializeField] private int coins;
        [SerializeField] private int score;
        [SerializeField] private List<TowerData> unlockedTowerList;
        [SerializeField] private List<LevelData> levelList;
        [SerializeField] private bool isFirstTime;
        private Data.LevelData levelSelected;
        private static GameState instance;

        public static GameState Instance
        {
            get
            {
                return instance;
            }
        }

        public Data.LevelData LevelSelected
        {
            get{ return levelSelected;}
        }

         private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Initializer();
        }

        public void Initializer()
        {
            coins = gameStateData.Coins;
            score = gameStateData.Score;
            unlockedTowerList = gameStateData.UnlockedTowerList;
            isFirstTime = gameStateData.IsFirstTime;
            levelList = gameStateData.LevelList;
            levelSelected = gameStateData.LevelList[0];

        }

        public void AddCoins(int amount)
        {
            coins += amount;
            SaveData();
        }

        public void AddScore(int amount)
        {
            score += amount;
            SaveData();
        }

        public void AddUnlockedTower(TowerData tower)
        {
            unlockedTowerList.Add(tower);
            SaveData();
        }


        public void SelectLevel(LevelData level)
        {
            levelSelected = level;
        }

        private void SaveData()
        {
            gameStateData.Coins = coins;
            gameStateData.Score = score;
            gameStateData.IsFirstTime = isFirstTime;
            gameStateData.LevelList = levelList;
            gameStateData.UnlockedTowerList = unlockedTowerList;
        }
    }
}