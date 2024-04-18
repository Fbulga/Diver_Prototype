using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EnemyTypes", menuName = "Enemy/EnemyTypes")]
public class EnemiesPrefabsList : ScriptableObject
{
    [field: SerializeField] public List<Enemy> enemiesPrefabs { get; private set; } = new();
}
