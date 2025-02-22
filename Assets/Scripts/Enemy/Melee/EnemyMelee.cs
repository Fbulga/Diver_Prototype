using Unity.VisualScripting;
using UnityEngine;


public class EnemyMelee : Enemy
{
    [SerializeField] private EnemyData enemyData;
    private Vector3 _distance;
    [SerializeField] private Rigidbody _rb;
    void Start()
    {
        Life = enemyData.Life;
        Speed = enemyData.Speed;
        Attack = enemyData.Attack;
        AttackReady = true;
        Counter = enemyData.TimeBetweenAttacks;
        BloodParticles = enemyData.BloodParticleSystem;
 

    }
    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            RotateTowardPlayer(player);
            
            _distance = player.gameObject.transform.position - transform.position;
            if (Mathf.RoundToInt(_distance.magnitude) > 0f && AttackReady)
            {
                Follow(_distance);
            }
            else if (!AttackReady)
            {
                Counter += Time.deltaTime;
                if (Counter >= enemyData.TimeBetweenAttacks)
                {
                    AttackReady = true;
                    Counter = 0f;
                }
            }
        }
    }
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (other.gameObject.TryGetComponent(out IDamagable oxygenReservoir))
            {
                oxygenReservoir.GetDamage(Attack);
                other.rigidbody.AddForce((other.transform.position - this.transform.position).normalized*enemyData.ImpulseForce,ForceMode.Impulse);
            }
            AttackReady = false;
        }
    }
    
    private void Follow(Vector3 direction)
    {
        direction = direction.normalized;
        _rb.AddForce((direction*enemyData.ImpulseForce),ForceMode.Impulse);
    }
}
