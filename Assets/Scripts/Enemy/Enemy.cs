
using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable, ISpawnable
{
     protected float Life;
     protected float Attack;
     protected float Speed;
     protected ParticleSystem BloodParticles;
     protected bool AttackReady;
     protected float Counter;
     protected int TimeBetweenAttacks;

    public void GetDamage(float damage)
    {
        Life -= damage;
        Debug.Log("Enemy Damaged. Life left: " + Life);
        if(Life <= 0f)
        {
            Destroy(this.gameObject);
            ParticleSystem ps = Instantiate(BloodParticles,this.transform.position,this.transform.rotation);
            ps.Play(true);
        }
    }

    protected void RotateTowardPlayer(Collider player)
    {
        Vector3 playerPosition = player.gameObject.transform.position;
        Quaternion lookAt = Quaternion.LookRotation(playerPosition -transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAt, Speed);
    }


}
