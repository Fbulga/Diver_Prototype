using UnityEngine;

[CreateAssetMenu(fileName = "OxygenTank" , menuName = "OxygenTank")]
public class OxygenTankType : ScriptableObject
{
    [field: SerializeField] public float OxygenCapacity { get; private set; }
    [field: SerializeField] public float ExplosionRadius { get; private set; }
    [field: SerializeField] public float ExplosionDamage { get; private set; }
    [field: SerializeField] public ParticleSystem ExplosionParticleSystem { get; private set; }
    [field: SerializeField] public Material DetailMaterial { get; private set; }
    
}
