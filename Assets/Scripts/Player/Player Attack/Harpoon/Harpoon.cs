using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private ParticleSystem bloodParticleSystem;

    [SerializeField] private int bulletAmmo;
    // Update is called once per frame


    public static Harpoon Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletAmmo>0)
        {
            var positionShootingpoint = shootingPoint.position;
            var bullet = Instantiate(bulletPrefab, positionShootingpoint, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = shootingPoint.up * bulletSpeed;
            bulletAmmo--;
            var ps = Instantiate(bloodParticleSystem,shootingPoint.transform);
            ps.Play(true);
        }
    }

    public void AddAmmo(int ammoAmount)
    {
        bulletAmmo += ammoAmount;
    }
    
   
}

