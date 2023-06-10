using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Towers/Tower")]
public class TowerData : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private string towerName;
    [SerializeField] private float fireRate;
    [SerializeField] private float attackRange;
    [SerializeField] private int upgradeLevel;
    [SerializeField] private int maxUpgradeLevel;
    [SerializeField] private int towerCost;
    [SerializeField] private int upgradeCost;

    public int Damage => damage;
    public string TowerName => towerName;
    public float FireRate => fireRate;
    public float AttackRange => attackRange;
    public int UpgradeLevel => upgradeLevel;
    public int MaxUpgradeLevel => maxUpgradeLevel;
    public int TowerCost => towerCost;
    public int UpgradeCost => upgradeCost;
}