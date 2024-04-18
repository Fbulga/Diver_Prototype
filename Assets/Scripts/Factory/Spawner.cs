using UnityEngine;

public class Spawner : MonoBehaviour
{
    private string _enemy = "Melee";
    private void Start()
    {
        SpawnEnemyMelee();
    }

    public void SpawnEnemyMelee()
    {
        var spawnEnemy = new EnemyFactory();
        var enemyMelee = spawnEnemy.CreateEnemy(_enemy);
        //Instantiate(enemyMelee, transform.position, transform.rotation);
    }
}
    