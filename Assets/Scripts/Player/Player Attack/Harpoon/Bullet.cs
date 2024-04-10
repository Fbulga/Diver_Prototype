using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destructionTime;

    [SerializeField] private float bulletDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destructionTime);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable enemyGameObject) && 
            (other.gameObject.layer == LayerMask.NameToLayer("Enemy") ||other.gameObject.layer == LayerMask.NameToLayer("Interactable")))
        {
            enemyGameObject.GetDamage(bulletDamage);
            Destroy(this.gameObject);
        }

    }
    
}
