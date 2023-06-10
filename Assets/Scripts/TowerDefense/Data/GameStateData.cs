using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
using TowerDefense.Tower;

[CreateAssetMenu(fileName = "NewGameStateData", menuName = "Game/GameStateData")]
public class GameStateData : ScriptableObject
{
    [SerializeField] private int coins;
    [SerializeField] private int score;
    [SerializeField] private List<TowerData> unlockedTowerList;
    [SerializeField] private List<LevelData> levelList;
    [SerializeField] private bool isFirstTime;

    public int Coins
    {
        get { return coins; }
        set { coins = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public List<TowerData> UnlockedTowerList
    {
        get { return unlockedTowerList; }
        set { unlockedTowerList = value; }
    }

    public List<LevelData> LevelList
    {
        get { return levelList; }
        set { levelList = value; }
    }

    public bool IsFirstTime
    {
        get { return isFirstTime; }
        set { isFirstTime = value; }
    }
}

    
    
