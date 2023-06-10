using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Enemy;

namespace TowerDefense.Tower
{
    public class AreaAttackTower : Tower
    {
        public override void Fire()
        {
            base.Fire();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, model.AttackRange);
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<IEnemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(model.Damage);
                }
            }
        }

        public override void Upgrade()
        {
            base.Upgrade();
        }
    }
}
