using UnityEngine;


namespace Factory
{
    [CreateAssetMenu(fileName = "EnemyCommandFactory", menuName = "EnemyCommandFactory", order = 0)]
    public class EnemyCommandGenerator : ScriptableObject
    {
        [SerializeField] private EnemyFactoryInitializer enemyFactoryInitializer;

        public bool TryGenerateEnemyCreationCommand(string enemyType, Vector3 position,Quaternion rotation, out ICommand command)
        {
            var enemy = enemyFactoryInitializer.GetEnemy(enemyType);
            command = new CreateEnemyCoommand(enemy, position,rotation);
            return command != null;
        }
    }
}