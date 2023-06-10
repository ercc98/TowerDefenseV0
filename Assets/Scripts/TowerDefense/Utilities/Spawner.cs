using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Enemy;

namespace TowerDefense.Utilities
{
    public class Spawner : MonoBehaviour
    {
        public event System.Action<GameObject> OnSpawned;
        protected GameObject spawnGameObject;
        [SerializeField] protected List<GameObject> gameObjectList;
        [SerializeField] protected Transform spawnPoint;
        [SerializeField] protected float spawnInterval = 2f;
        [SerializeField] protected int maxGameObjects = 10;

        public GameObject SpawnGameObject
        {
            set { spawnGameObject = value; }
        }

        public Transform SpawnPoint
        {
            set { spawnPoint = value; }
        }

        public float SpawnInterval
        {
            set { spawnInterval = value; }
        }

        public int MaxGameObjects
        {
            set { maxGameObjects = value; }
        }

        private int currentGameObjectCount = 0;

        private void Start() 
        {
        }
        private void Update() 
        {
        }
        public virtual void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        protected virtual IEnumerator Spawn()
        {
            while (currentGameObjectCount < maxGameObjects)
            {
                GameObject newGameObject = GetInactive();
                if (newGameObject != null)
                {
                    Activate(newGameObject);
                }
                else
                {
                    newGameObject = InstantiateNewObject();
                }
                OnSpawned?.Invoke(newGameObject);
                currentGameObjectCount++;
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        protected virtual GameObject GetInactive()
        {
            if (gameObjectList.Count == 0)
            {
                return null;
            }
            foreach (GameObject gameObject in gameObjectList)
            {
                if (!gameObject.activeSelf)
                {
                    return gameObject;
                }
            }
            return null;
        }

        protected virtual void Activate(GameObject gameObject)
        {
            gameObject.transform.position = spawnPoint.position;
            gameObject.SetActive(true);

        }

        protected virtual GameObject InstantiateNewObject()
        {
            GameObject newGameObject = Instantiate(spawnGameObject, spawnPoint.position, spawnPoint.rotation);
            gameObjectList.Add(newGameObject);
            return newGameObject;
        }
    }
}