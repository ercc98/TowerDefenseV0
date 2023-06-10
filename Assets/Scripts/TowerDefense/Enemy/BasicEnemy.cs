using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Enemy
{
    public class BasicEnemy : Enemy
    {        
        public override void Move()
        {
            base.Move();
        }

        public override void TakeDamage(int damage)
        {
           base.TakeDamage(damage);      
        }

        public override void Die()
        {
            base.Die();
        }
    }
}