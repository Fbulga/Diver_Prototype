using UnityEngine;

public class EnemyFactory : AbstractFactory<Enemy>
{

    
    public const string ENEMY_MELEE = "Melee";
    public const string ENEMY_LONG_RANGE = "Long Range";
    public const string ENEMY_MINE = "Mine";
    
    [SerializeField] private EnemiesPrefabsList enemyPrefabs;
    private Enemy enemyPrefab;
    
    public override Enemy CreateEnemy(string enemyType)
    {
        return GetEnemyType(enemyType);
    }

    public Enemy GetEnemyType(string enemyType)
    {
        switch (enemyType)
        {
            case ENEMY_MELEE:
                return enemyPrefabs.enemiesPrefabs[0];
            case ENEMY_LONG_RANGE:
                return enemyPrefabs.enemiesPrefabs[1];
            case ENEMY_MINE:
                return enemyPrefabs.enemiesPrefabs[2];
        }
        return default;
    }
    
    public void Initialize(Enemy enemyPrefab)
    {
        this.enemyPrefab = enemyPrefab;
    }
    
}
