using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
     protected float life;
     protected float attack;
     protected float speed;
     protected LayerMask playerLayer;
     protected ParticleSystem bloodParticles;

    public void GetDamage(float damage)
    {
        life -= damage;
        Debug.Log("Enemy Damaged. Life left: " + life);
        if(life <= 0f)
        {
            Destroy(this.gameObject);
            ParticleSystem ps = Instantiate(bloodParticles,this.transform.position,this.transform.rotation);
            ps.Play(true);
        }
    }
}
