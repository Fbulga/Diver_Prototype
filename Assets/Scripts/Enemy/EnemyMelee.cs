using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMelee : Enemy
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private int timeBetweenAttacks;
    private Vector3 distance;
    private bool attackReady;
    private float counter;


    //Metodo 1
    /*public bool playerIn;
    public Collider[]  colliders = new Collider[2];*/

    // Start is called before the first frame update
    void Start()
    {
        life = enemyData.Life;
        speed = enemyData.Speed;
        attack = enemyData.Attack;
        playerLayer = enemyData.PlayerLayer;
        attackReady = true;
        counter = timeBetweenAttacks;
    }

    //Metodo 1
    /*private void Update()
    {
        if (colliders[0] != null)
        {
            Vector3 playerPosition = colliders[0].gameObject.transform.position;

            Quaternion lookAt = Quaternion.LookRotation(playerPosition - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAt, speed);

            distance = playerPosition - transform.position;
            distancia = Mathf.RoundToInt(distance.magnitude);
            if (Mathf.RoundToInt(distance.magnitude) > 0f && attackReady)
            {
                Follow(distance);
            }
            else if (!attackReady)
            {
                counter += Time.deltaTime;
                if (counter >= timeBetweenAttacks)
                {
                    attackReady = true;
                    counter = 0f;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliders = Physics.OverlapSphere(transform.position, colliderSphere.radius, playerLayer);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out OxygenReservoir player))
            {
                playerIn = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders.SetValue(null,i);
        }
        playerIn = false;
    }*/

    //Metodo 2
    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Vector3 playerPosition = player.gameObject.transform.position;
            
            Quaternion lookAt = Quaternion.LookRotation(playerPosition -transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAt, speed);

            distance = playerPosition - transform.position;
            if (Mathf.RoundToInt(distance.magnitude) > 0f && attackReady)
            {
                Follow(distance);
            }
            else if (!attackReady)
            {
                counter += Time.deltaTime;
                if (counter >= timeBetweenAttacks)
                {
                    attackReady = true;
                    counter = 0f;
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
            attackReady = false;
        }
    }
    
    private void Follow(Vector3 direction)
    {
        direction = direction.normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
