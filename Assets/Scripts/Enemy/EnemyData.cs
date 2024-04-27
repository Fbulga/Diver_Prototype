using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData" , menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public Enemy Prefab { get; private set; }
    
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public float Life { get; private set; }
    [field: SerializeField] public float Attack { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int ImpulseForce { get; private set; }
    [field: SerializeField] public ParticleSystem BloodParticleSystem { get; private set; }
    [field: SerializeField] public int TimeBetweenAttacks { get; private set; }
}