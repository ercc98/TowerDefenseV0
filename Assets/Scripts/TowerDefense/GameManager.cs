using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Enemy;
using TowerDefense.Utilities;
using TowerDefense.Data;
using TMPro; 
namespace TowerDefense
{
    public class GameManager: MonoBehaviour
    {
        [SerializeField] private int currentCoins;
        [SerializeField] private int currentScore;
        [SerializeField] private int currentEnergy;
        [SerializeField] private bool isPaused;
        [SerializeField] private float timePerGame;
        [SerializeField] private Data.LevelData level;
        [SerializeField] private Spawner spawnerPrefab;
        private List<Spawner> spawnerList;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform goal;
        private List<IEnemy> enemyList;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI lifeText;


        private float initialTime;
        public int CurrentCoins { get => currentCoins; set => currentCoins = value; }
        public int CurrentScore { get => currentScore; set => currentScore = value; }
        public int CurrentEnergy { get => currentEnergy; set => currentEnergy = value; }
        public bool IsPaused { get => isPaused; set => isPaused = value; }
        public float TimePerGame { get => timePerGame; set => timePerGame = value; }
       
        private void OnEnable() 
        {

        }

        private void OnDisable() 
        {            
            foreach (Spawner spawner in spawnerList)
            { 
                UnsubscribeFromOnSpawner(spawner);
            }

            foreach (IEnemy enemy in enemyList)
            { 
                UnsubscribeFromEnemyDeath(enemy);
            }
        }

        private void HandleEnemyReachedDestination(IEnemy enemy)
        {
            currentEnergy -= enemy.GetDamage();
            if(CurrentEnergy <= 0 )
            {
                GameOver();
            }
        }

        public void SubscribeToEnemyDeath(IEnemy enemy)
        {
            enemy.OnEnemyDeath += HandleEnemyDeath;
            enemy.OnEnemyReachedDestination += HandleEnemyReachedDestination;
        }

        public void UnsubscribeFromEnemyDeath(IEnemy enemy)
        {
            enemy.OnEnemyDeath -= HandleEnemyDeath;
            enemy.OnEnemyReachedDestination -= HandleEnemyReachedDestination;
        }

        private void HandleEnemyDeath(IEnemy enemy)
        {
            currentScore += enemy.GetScore();
            currentCoins += enemy.GetScore(); //El score son las monedas pero esas se gastan
            enemy.OnEnemyDeath -= HandleEnemyDeath;
            enemy.OnEnemyReachedDestination -= HandleEnemyReachedDestination;            
        }

        public void SubscribeToOnSpawner(Spawner spawner)
        {            
            spawner.OnSpawned += HandlerOnSpawned;
        }

        public void UnsubscribeFromOnSpawner(Spawner spawner)
        {
            spawner.OnSpawned -= HandlerOnSpawned;
        }

        private void HandlerOnSpawned(GameObject spawnGameObject)
        {
            IEnemy newEnemy = spawnGameObject.GetComponent<IEnemy>();
            newEnemy.SetGoal(goal.position);
            SubscribeToEnemyDeath(newEnemy);
            enemyList.Add(newEnemy);
        }


        private void Start() 
        {
            level = GameState.Instance.LevelSelected;
            Initializer();
        }

        private void Initializer()
        {
            enemyList = new List<IEnemy>();
            spawnerList = new List<Spawner>();
            currentCoins = level.InitialCoins;
            currentScore = 0;
            currentEnergy = level.Energy;
            initialTime = Time.time;
            timePerGame = level.TimePerGame + initialTime;
            SetSpawners();
            StartSpawners();
        }

        private void SetSpawners()
        {
            
            foreach (EnemySpawnData enemySpawnDataList in level.EnemyDataList)
            {               
                Spawner newSpawner = Instantiate(spawnerPrefab.gameObject).GetComponent<Spawner>();
                SubscribeToOnSpawner(newSpawner);
                newSpawner.SpawnGameObject = enemySpawnDataList.enemyGameObject;
                newSpawner.SpawnPoint = spawnPoint;
                newSpawner.SpawnInterval = enemySpawnDataList.SpawnTime;
                newSpawner.MaxGameObjects = enemySpawnDataList.EnemyCount;
                spawnerList.Add(newSpawner);                
            }
        }

        private void StartSpawners()
        {
            StartCoroutine(StartSpawnersCorroutine());
        }

        private IEnumerator StartSpawnersCorroutine()
        {
            int StartTimeToSpawn = 5;
            foreach (Spawner spawner in spawnerList)
            {                
                yield return new WaitForSeconds(StartTimeToSpawn);
                spawner.StartSpawn();
            }
        }

        private void Update() 
        {

            scoreText.text = "Score: " + currentScore;
            timeText.text = "tiempo: " + (timePerGame - Time.time);
            lifeText.text = "Vida restante: " + currentEnergy;
            if(Time.time >= timePerGame)
            {
                GameOver();
            }
        }

        public void GameOver()
        {
            Debug.Log("GameOver");
            if(currentEnergy > 0)
            {
                WinGame();
            }
            else
            {
                LoseGame();
            }
            SceneLoader.Instance.LoadSceneAsync("MainMenu");
        }

        public void WinGame()
        {
            Debug.Log("Ganaste");
            GameState.Instance.AddCoins(currentCoins);
            GameState.Instance.AddScore(currentScore);
        }

        public void LoseGame()
        {
            Debug.Log("Perdiste");
            GameState.Instance.AddCoins(currentCoins / 10);
            GameState.Instance.AddScore(currentScore / 10);
        }
    }
}