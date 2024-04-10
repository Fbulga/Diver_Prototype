using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class OxygenTank : MonoBehaviour, IInteractable, IDamagable
{
    [SerializeField] private OxygenTankType oxygenTank;

    private void OxygenTankInteract()
    {
        OxygenReservoir.Instance.AddOxygen(oxygenTank.OxygenCapacity);
        Destroy(gameObject);
    }

    public void Interact()
    {
        OxygenTankInteract();
    }

    public void GetDamage(float damage)
    {
        Explosion();
    }

    private void Explosion()
    {
        Debug.Log("explosion");
        Collider[] inRange = Physics.OverlapSphere(transform.position, oxygenTank.ExplosionRadius);

        foreach (Collider affected in inRange)
        {
            if (affected.gameObject.TryGetComponent(out IDamagable affectedGameObject) && this.gameObject != affected.gameObject)
            {
                affectedGameObject.GetDamage(oxygenTank.ExplosionDamage);
            }
        }
        ParticleSystem ps = Instantiate(oxygenTank.ExplosionParticleSystem,this.transform.position,this.transform.rotation);
        ps.Play(true);
        Destroy(this.gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, oxygenTank.ExplosionRadius);
    }


}
