using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Enemy
{
    public interface IEnemy
    {
        event Action<IEnemy> OnEnemyDeath;
        event Action<IEnemy> OnEnemyReachedDestination;
        void TakeDamage(int damage);
        void Die();
        void Move();
        void SetPosition(Vector3 position);
        void ActivateEnemy();
        void DeactivateEnemy();
        bool IsGameObjectActive();
        int GetScore();
        int GetDamage();
        void SetGoal(Vector3 goal);
        void SlowDown(int reduceSpeed);
    }
}