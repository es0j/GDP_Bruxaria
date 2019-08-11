using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Aparently besides built in sizeof C# also has typeof, interesting..
//requires an navmesh agent to use class
[RequireComponent(typeof(NavMeshAgent))]
public class playerMotor : MonoBehaviour
{


    NavMeshAgent guy;
    Transform target=null;

    // Start is called before the first frame update
    void Start()
    {
        guy = GetComponent<NavMeshAgent>();    
    }

    IEnumerator waitAndFollow()
    {
        while (target)
        {
            guy.SetDestination(target.position);
            yield return new WaitForSeconds(0.05f);
        }
    }
    


    public void MoveTo(Vector3 point)
    {
        guy.SetDestination(point);
    }

    public void follow(Interactable focus)
    {
        guy.stoppingDistance = focus.radius * .8f;
        target = focus.interactionTransform;
        StartCoroutine(waitAndFollow());

        guy.updateRotation = false;
    }

    public void leave()
    {
        guy.stoppingDistance = 0f;
        target = null;
        guy.updateRotation = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        //wtf is an quaternion
        Vector3 movement = new Vector3(direction.x, 0, direction.z);
        if (movement != Vector3.zero)
        {
            Quaternion lookRot = Quaternion.LookRotation(movement);

            //interpolation for smoooth
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5);
            
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            FaceTarget();
        }
    }
}
