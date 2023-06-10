using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Enemy
{
    public class SpeedyEnemy : Enemy
    {
        private int lifes;
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
            if(lifes <= 0)
            {
                base.Die();
            }
            else
            {
                lifes--;
                currentHealth = (model.Health / 2);
            }
        }
    }
}