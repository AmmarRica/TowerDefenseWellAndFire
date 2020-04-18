using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public bool isFiring = false;

    public Transform spawn;
    public float shotdistance = 20;

    public ParticleSystem particleSystem;

    public BulletController bullet;
    public float bulletSpeed = 5f;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    public void Shoot()
    {
        Ray ray = new Ray(spawn.position, spawn.forward);
        RaycastHit hit;
        

        if(Physics.Raycast(ray,out hit, shotdistance))
        {
            shotdistance = hit.distance;
        }
        Debug.DrawRay(ray.origin, ray.direction * shotdistance, Color.red,1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.speed = bulletSpeed;

                particleSystem.Play();
            }
        }
        else
        {
            shotCounter = 0;
            particleSystem.Stop();
        }
    }
}
