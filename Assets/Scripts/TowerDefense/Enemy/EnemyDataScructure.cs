using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.Enemy;
using UnityEngine;

namespace TowerDefense.Enemy
{ 
    [Serializable]
    public struct EnemySpawnData
    {
        public GameObject enemyGameObject;
        public int EnemyCount;
        public float SpawnTime;
}
}

