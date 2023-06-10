using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemies/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string enemyName;
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int score;
    [SerializeField] private int damage;

    public string EnemyName => enemyName;
    public int Health => health;
    public int Speed => speed;
    public int Score => score;
    public int Damage => damage;
}