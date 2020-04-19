using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage = 1;
    public float pushForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is hit");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player is hit");

            //waterSupply = waterSupply + (Time.deltaTime * waterAddRate);
            var playerStats = collider.gameObject.GetComponent<CharacterStats>();
            if (playerStats)
            {
                playerStats.TakeDamage(enemyDamage);
                //push back the player maybe
                PushGameObjectAway(this.gameObject, playerStats.gameObject, pushForce);
            }
        }
    }

    private void PushGameObjectAway(GameObject fromObject, GameObject pushedObject, float pushForce)
    {
        Vector3 direction =  pushedObject.transform.position - fromObject.transform.position;
        var rbPushed = pushedObject.gameObject.GetComponent<Rigidbody>();
        if (rbPushed)
        {
            rbPushed.AddForce(direction * pushForce, ForceMode.Impulse);
        }
    }
}
