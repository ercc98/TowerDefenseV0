using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Enemy
{
    public class ToughtEnemy : Enemy
    {
        private int shield;

        public override void Move() 
        {
            base.Move();
        }

        public override void TakeDamage(int damage)
        {
           if (shield > 0)
            {
                shield -= damage;
                if (shield < 0)
                {
                    shield = 0;
                }
            }
            else
            {
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    Die();
                }
            }     
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
