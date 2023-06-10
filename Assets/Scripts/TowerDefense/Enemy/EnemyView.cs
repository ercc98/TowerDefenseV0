using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        // Método para activar el GameObject
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        // Método para desactivar el GameObject
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public bool IsGameObjectActive()
        {
            return gameObject.activeSelf;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position =position;
        }

        public void Move(Vector3 direction, float distance, float speed)
        {
            transform.Translate(direction * distance * speed * 0.0001f);
        }

        public void Die()
        {
            Deactivate();
        }
    }
}
