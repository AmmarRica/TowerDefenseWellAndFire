using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    public Transform spawn;
    public float shotdistance = 20;

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
        
    }
}
