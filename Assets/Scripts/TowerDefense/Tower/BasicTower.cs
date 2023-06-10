using System.Collections;
using System.Collections.Generic;
using TowerDefense.Enemy;
using UnityEngine;

namespace TowerDefense.Tower
{
    public class BasicTower : Tower
    {
        public override void Fire()
        {
            
            base.Fire();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, model.AttackRange);
            if (hitColliders != null && hitColliders.Length > 0)
            {
                var firstEnemyCollider = hitColliders[0];
                var firstEnemy = firstEnemyCollider.GetComponent<IEnemy>();
                if (firstEnemy != null)
                {
                    firstEnemyCollider.SendMessage("TakeDamage", model.Damage);
                }
            }
        }

        public override void Upgrade()
        {
            base.Upgrade();
        }
    }
}
