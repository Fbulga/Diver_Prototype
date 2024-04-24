using UnityEngine;

[CreateAssetMenu(fileName = "NewFactoryInitializer", menuName = "Factory/EnemyInitializer", order = 0)]
public class FactoryInitializer : ScriptableObject
{
    private EnemyFactory enemyFactory = new();
    [SerializeField] private Enemy meleePrefab;
    [SerializeField] private Enemy longRangePrefab;
    [SerializeField] private Enemy landminePrefab;

    public Enemy GetEnemy(string enemyType)
    {
        if (!enemyFactory.Initialized)
        {
            switch (enemyType)
            {
                case EnemyFactory.ENEMY_MELEE:
                    enemyFactory.Initialize(meleePrefab);
                    break;
                case EnemyFactory.ENEMY_LONG_RANGE:
                    enemyFactory.Initialize(longRangePrefab);
                    break;
                case EnemyFactory.ENEMY_LANDMINE:
                    enemyFactory.Initialize(landminePrefab);
                    break;
            }
        }

        return enemyFactory.CreateEnemy(enemyType);
    }

}