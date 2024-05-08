using System;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private ParticleSystem bloodParticleSystem;
    [SerializeField] private int bulletAmmo;

    private IAmmoCanvasProvider ammoCanvasProvider => MainCanvas.Instance;
    
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

    private void Start()
    {
        ammoCanvasProvider.AmmoCanvas.DisplayText(bulletAmmo);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletAmmo>0)
        {
            var bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = shootingPoint.forward * bulletSpeed;
            bulletAmmo--;
            ammoCanvasProvider.AmmoCanvas.DisplayText(bulletAmmo);
            var ps = Instantiate(bloodParticleSystem,shootingPoint.transform);
            ps.Play(true);
        }
    }

    public void AddAmmo(int ammoAmount)
    {
        bulletAmmo += ammoAmount;
        ammoCanvasProvider.AmmoCanvas.DisplayText(bulletAmmo);
    }
    
   
}

