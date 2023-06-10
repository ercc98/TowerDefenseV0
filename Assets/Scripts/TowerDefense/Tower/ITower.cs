using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public interface ITower
    {
        void Fire();
        void Upgrade();
        int GetDamage();
    }
}