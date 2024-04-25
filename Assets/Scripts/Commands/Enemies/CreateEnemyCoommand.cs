using UnityEngine;

public class CreateEnemyCoommand : ICommand
{
    private Enemy enemyPrefab;
    private Vector3 position;
    private Quaternion rotation;
    private Enemy instance;

    public CreateEnemyCoommand(Enemy enemyPrefab, Vector3 position, Quaternion rotation)
    {
        this.enemyPrefab = enemyPrefab;
        this.position = position;
        this.rotation = rotation;
    }
    public void Execute()
    {
        instance = Object.Instantiate(enemyPrefab, position, rotation);
    }
}