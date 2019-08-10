using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class inputController2 : MonoBehaviour
{

    public float speed;

    NavMeshAgent agent;
    Vector3 movement;
    Vector3 vector;
    float moveHorizontal;
    float moveVertical;
    public float angleRotate = -90;
    public Transform pivot;
    public int index;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        if (index==0)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            vector = Quaternion.Euler(0, angleRotate, 0) * movement;

            agent.Move(vector * Time.deltaTime * speed);
            agent.SetDestination(transform.position+(vector * Time.deltaTime * speed));
            if (vector!=Vector3.zero)
            {
                Debug.Log(vector);
               
            }
            

        }
        else
        {
            //Debug.Log(PlayerManager.instance.GetMainPlayer().gameObject.GetComponentInChildren<inputController2>().pivot.position);
            agent.SetDestination(PlayerManager.instance.mainPlayer.GetComponentInChildren<inputController2>().pivot.position);
            transform.LookAt(PlayerManager.instance.mainPlayer.transform);
        }

    }
}