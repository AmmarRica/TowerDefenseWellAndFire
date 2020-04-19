using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public Vector3 size;
    public GameObject endPoint;
    public Transform target;

    NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {
        //target = PlayerManager1.instance.playerObj.transform;

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { return; }
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);


            if (distance <= agent.stoppingDistance)
            {
                //Attack the tar
                // Face the target
                FaceTarget();
            }
        }
        else
        {
            agent.SetDestination(endPoint.transform.position);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

}
