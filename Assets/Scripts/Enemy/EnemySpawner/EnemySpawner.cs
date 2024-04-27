using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyCommandGenerator enemyCommandGenerator;
    private string enemyType;

    enum EnemyType
    {
        Melee,
        LongRange,
        Landmine
    }
    
    [SerializeField] private EnemyType EnemyID;
    private void Awake()
    {
        switch (EnemyID)
        {
            case EnemyType.Melee:
                enemyType = "Melee";
                break;
            case EnemyType.Landmine:
                enemyType = "Landmine";
                break;
            case EnemyType.LongRange:
                enemyType = "Long Range";
                break;
            default:
                enemyType = "Melee";
                break;
        }
    }

    private void Start()
    {
        GenerateEnemy(enemyType);
    }

    private void GenerateEnemy(string enemyType)
    {
        if (!enemyCommandGenerator.TryGenerateEnemyCreationCommand(enemyType,
                transform.position,transform.rotation, out var enemyCommand))
        {
            return;
        }
            
        EventQueue.Instance.EnqueueCommand(enemyCommand);
    }
    
}

