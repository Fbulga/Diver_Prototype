using UnityEngine;


public class EnemyMelee : Enemy
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private int timeBetweenAttacks;
    private Vector3 _distance;
    private bool _attackReady;
    private float _counter;

    void Start()
    {
        life = enemyData.Life;
        speed = enemyData.Speed;
        attack = enemyData.Attack;
        playerLayer = enemyData.PlayerLayer;
        _attackReady = true;
        _counter = timeBetweenAttacks;
        bloodParticles = enemyData.BloodParticleSystem;
    }
    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Vector3 playerPosition = player.gameObject.transform.position;
            
            Quaternion lookAt = Quaternion.LookRotation(playerPosition -transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAt, speed);

            _distance = playerPosition - transform.position;
            if (Mathf.RoundToInt(_distance.magnitude) > 0f && _attackReady)
            {
                Follow(_distance);
            }
            else if (!_attackReady)
            {
                _counter += Time.deltaTime;
                if (_counter >= timeBetweenAttacks)
                {
                    _attackReady = true;
                    _counter = 0f;
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
                oxygenReservoir.GetDamage(attack);
                other.rigidbody.AddForce((other.transform.position - this.transform.position).normalized*enemyData.ImpulseForce,ForceMode.Impulse);
            }
            _attackReady = false;
        }
    }
    
    private void Follow(Vector3 direction)
    {
        direction = direction.normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
}
