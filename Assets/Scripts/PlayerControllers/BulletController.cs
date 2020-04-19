using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody rb;

    public float bulletLifeTime = 3;
    public int damageToFire = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        bulletLifeTime -= Time.deltaTime;
        if(bulletLifeTime <=0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
    //        Debug.Log("Bullet collided with: "+collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            //Destroy(collision.gameObject, 0.1f);
            var enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            if(enemyStats != null)
            {
                enemyStats.TakeDamage(damageToFire);
            }
        }
    }
}
