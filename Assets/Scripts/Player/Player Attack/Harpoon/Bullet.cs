using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destructionTime;
    [SerializeField] private float bulletDamage;
    [SerializeField] private ParticleSystem impactParticle;
    
    void Start()
    {
        Destroy(this.gameObject, destructionTime);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable enemyGameObject) && 
            other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            enemyGameObject.GetDamage(bulletDamage);
            ParticleSystem ps = Instantiate(impactParticle,this.transform.position,this.transform.rotation);
            ps.Play(true);
            Destroy(this.gameObject);
        }

    }
    
}
