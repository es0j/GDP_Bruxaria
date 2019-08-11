using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10;
    public Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        //if (target==null)
        //{
        target = PlayerManager.instance.player.transform;
        //}
        
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    IEnumerator waitAndFollow()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);
        
        if (distance <= lookRadius)
        {
            FaceTarget();
            agent.SetDestination(target.position);
            //Debug.Log(distance.ToString() + ":" + agent.stoppingDistance.ToString());
            if (distance <= (agent.stoppingDistance+1))
            {
                
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if(targetStats!=null)
                {
                    
                    combat.Attack(targetStats);
                }
                
                
            }
            
        }
        yield return new WaitForSeconds(0.05f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //FaceTarget();
        //waitAndFollow();
        StartCoroutine(waitAndFollow());

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*8f);
        transform.rotation = lookRotation;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red ;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
