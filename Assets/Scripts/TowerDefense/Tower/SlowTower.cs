using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Enemy;

namespace TowerDefense.Tower
{
    public class SlowTower : Tower
    {
        [SerializeField] private int reduceSpeed;
        [SerializeField] private SphereCollider sphereCollider;

        private void OnEnable() 
        {
            sphereCollider.radius = model.AttackRange;
        }

        public override void Upgrade()
        {
            base.Upgrade();
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<IEnemy>();
                if (enemy != null)
                {
                    enemy.SlowDown(reduceSpeed);
                }
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<IEnemy>();
                if (enemy != null)
                {
                    enemy.SlowDown(0);
                }
            }
        }        
    }
}
