using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Enemy;

namespace TowerDefense.Tower
{
    public class Tower : MonoBehaviour, ITower
    {
        [SerializeField] protected TowerData model;
        [SerializeField] protected TowerView view;

        protected void Start() 
        {
            StartCoroutine(FireCoroutine());
        }
        public virtual void Fire()
        {
            view.Fire();                     
        }

        protected virtual IEnumerator FireCoroutine()
        {
            while (true)
            {
                Fire();
                yield return new WaitForSeconds(model.FireRate);                
            }
        }

        public virtual void Upgrade()
        {
            view.Upgrade();
        }

        public virtual int GetDamage()
        {
            return model.Damage;
        }
    }
}