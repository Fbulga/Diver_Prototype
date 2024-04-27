using UnityEngine;
using System.Collections.Generic;

public class EnemyFactory : AbstractFactory<Enemy>
{
    public const string ENEMY_MELEE = "Melee";
    public const string ENEMY_LONG_RANGE = "Long Range";
    public const string ENEMY_LANDMINE = "Landmine";
    
    public bool Initialized { get; private set; }
    
    private Enemy enemyPrefab;
    
    public override Enemy CreateEnemy(string enemyType)
    {
        switch (enemyType)
        {
            case ENEMY_MELEE:
                return enemyPrefab;
            case ENEMY_LONG_RANGE:
                return enemyPrefab;
            case ENEMY_LANDMINE:
                return enemyPrefab;
        }
        return default;
    }

    public void Initialize(Enemy enemyPrefab)
    {
        this.enemyPrefab = enemyPrefab;
        Initialized = true;
    }
}
