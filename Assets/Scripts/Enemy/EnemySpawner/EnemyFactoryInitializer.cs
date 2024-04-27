using UnityEngine;

[CreateAssetMenu(fileName = "NewFactoryInitializer", menuName = "Factory/EnemyFactoryInitializer", order = 0)]
public class EnemyFactoryInitializer : ScriptableObject
{
    private EnemyFactory enemyFactory = new();

    [SerializeField] private EnemyData[] _enemyDatas;

    public Enemy GetEnemy(string enemyType)
    {
        if (!enemyFactory.Initialized)
        {
            foreach (var enemy in _enemyDatas)
            {
                if (enemyType == enemy.ID)
                {
                    enemyFactory.Initialize(enemy.Prefab);
                    break;
                }
            }
        }

        return enemyFactory.CreateEnemy(enemyType);
    }

}