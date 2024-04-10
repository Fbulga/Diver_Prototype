using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData" , menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float Life { get; private set; }
    [field: SerializeField] public float Attack { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public int ImpulseForce { get; private set; }
    [field: SerializeField] public LayerMask PlayerLayer { get; private set; }
    
    [field: SerializeField] public ParticleSystem BloodParticleSystem { get; private set; }
}