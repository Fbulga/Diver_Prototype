
using UnityEngine;

public class EnemyLandMine : Enemy
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private GameObject bodyLandMine;

    [SerializeField] private SphereCollider _collider;

    private int explodingScale;


    private bool _playerInRange;
    private float _bombForce;
    private Vector3 _initialScale;

    void Start()
    {
        Life = enemyData.Life;
        _bombForce = enemyData.ImpulseForce;
        Attack = enemyData.Attack;
        Speed = enemyData.Speed;
        BloodParticles = enemyData.BloodParticleSystem;
        explodingScale = enemyData.TimeBetweenAttacks;
        _initialScale = bodyLandMine.transform.localScale;
    }

    private void Update()
    {
        if (_playerInRange == false && Mathf.RoundToInt(bodyLandMine.transform.localScale.magnitude) != Mathf.RoundToInt(_initialScale.magnitude))
        {
            bodyLandMine.transform.localScale -= new Vector3(1,1,1) * Time.deltaTime;
            _collider.radius -= Time.deltaTime/2;
        }
    }

    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            RotateTowardPlayer(player);
            _playerInRange = true;
            bodyLandMine.transform.localScale += new Vector3(1,1,1) * Time.deltaTime;
            _collider.radius += Time.deltaTime/2;
        }

        if (bodyLandMine.transform.localScale.magnitude >= new Vector3(explodingScale, explodingScale, explodingScale).magnitude)
        {
            Explode(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _playerInRange = false;
    }

    private void Explode(Collider player)
    {
        if (player.gameObject.TryGetComponent(out IDamagable oxygenReservoir))
        {
            Destroy(this.gameObject);
            player.gameObject.TryGetComponent(out Rigidbody rigidbody);
            oxygenReservoir.GetDamage(Attack);
            ParticleSystem ps = Instantiate(BloodParticles,this.transform.position,this.transform.rotation);
            ps.Play(true);
            rigidbody.AddForce((player.transform.position - this.transform.position).normalized*_bombForce,ForceMode.Impulse);
        }
    }
}
