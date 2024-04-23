using UnityEngine;

public class EnemyLongRange : Enemy
{
    [SerializeField] private EnemyData enemyData;
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private ParticleSystem shootingParticles;
    

    private float _bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Life = enemyData.Life;
        _bulletSpeed = enemyData.ImpulseForce;
        Attack = enemyData.Attack;
        AttackReady = true;
        Speed = enemyData.Speed;
        Counter = enemyData.TimeBetweenAttacks;
        BloodParticles = enemyData.BloodParticleSystem;
    }
    
    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            RotateTowardPlayer(player);
            
            if (AttackReady)
            {
                Shoot(bulletPrefab,shootingPoint);
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

    private void Shoot(GameObject bulletPrefab, Transform shootingPoint)
    {
        var bP = Instantiate(bulletPrefab, shootingPoint.position,shootingPoint.rotation);
        bP.GetComponent<Rigidbody>().velocity = shootingPoint.forward * _bulletSpeed;
        var ps = Instantiate(shootingParticles, shootingPoint.position,shootingPoint.rotation);
        ps.Play(true);
        AttackReady = false;
    }
}
