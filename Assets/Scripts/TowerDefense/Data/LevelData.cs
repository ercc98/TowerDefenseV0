using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Enemy;

namespace TowerDefense.Data
{
    [CreateAssetMenu(fileName = "NewLevelData", menuName = "Game/Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int energy;
        [SerializeField] private string visibleName;
        [SerializeField] private string slug;
        [SerializeField] private List<EnemySpawnData> enemyDataList;
        [SerializeField] private int initialCoins;
        [SerializeField] private float timePerGame;

        public int Energy
        {
            get { return energy; }
        }

        public string VisibleName
        {
            get { return visibleName; }
        }

        public string Slug
        {
            get { return slug; }
        }

        public List<EnemySpawnData> EnemyDataList
        {
            get { return enemyDataList; }
        }

        public int InitialCoins
        {
            get { return initialCoins; }
        }

        public float TimePerGame
        {
            get { return timePerGame; }
        }
    }
}