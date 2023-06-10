using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Enemy
{
    public class Enemy: MonoBehaviour, IEnemy
    {
        [SerializeField] protected EnemyData model;
        [SerializeField] protected EnemyView view;
        protected bool isDeath;
        [SerializeField] protected float currentSpeed;
        [SerializeField] protected int currentHealth;

        [SerializeField] protected Vector3 goal;


        public event System.Action<IEnemy> OnEnemyDeath;
        public event System.Action<IEnemy> OnEnemyReachedDestination;


        private void OnEnable() 
        {
            currentHealth = model.Health;
            currentSpeed = model.Speed;
            isDeath = false;
        }

        private void Update() 
        {
            Move();
        }
        public virtual void Move()
        {
            view.Move(goal, 1, currentSpeed);
        }

        public virtual void SetPosition(Vector3 position)
        {
            view.SetPosition(position);
        }

        public virtual void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if(!isDeath && currentHealth <= 0)
            {
                Die();
            }            
        }

        public virtual void Die()
        {
            view.Die();
            isDeath = true;
            OnEnemyDeath?.Invoke(this);
        }

        public void ActivateEnemy()
        {
            view.Activate();
            isDeath = false;
            currentHealth = model.Health;
            
        }

        public void DeactivateEnemy()
        {
            view.Deactivate();
            isDeath = true;            
        }

        public bool IsGameObjectActive()
        {
            return view.IsGameObjectActive();
        }
        public int GetScore()
        {
            return model.Score;
        }

        public int GetDamage()
        {
            return model.Damage;
        }

        public void SetGoal(Vector3 goal)
        {
            this.goal = goal;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Goal"))
            {
                OnEnemyReachedDestination?.Invoke(this);
                view.Deactivate();
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.CompareTag("SlowTower"))
            {
                SlowDown(0);
            }
        }

        public void SlowDown(int reduceSpeed)
        {
            currentSpeed = model.Speed - reduceSpeed;            
        }
    }
}
