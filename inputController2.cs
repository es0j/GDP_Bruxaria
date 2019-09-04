using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class inputController2 : MonoBehaviour
{

    public float speed;

    public Animator anim;
    public float angleRotate = -90;
    public Transform pivot;
    public int index;
    public float maxSpeed=10;
    public float jumpSpeed = 20;

    NavMeshAgent agent;
    Rigidbody rb;
    Vector3 movement;
    Vector3 vector;
    float moveHorizontal;
    float moveVertical;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -100.0F, 0);
    }

    void FixedUpdate()
    {
        if (index==0)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");


            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            vector = Quaternion.Euler(0, angleRotate, 0) * movement;

            //agent.Move(vector * Time.deltaTime * speed);
            //agent.SetDestination(transform.position+(vector * Time.deltaTime * speed));
            
            transform.LookAt(transform.position + (vector * Time.deltaTime * speed));
            if(rb.velocity.magnitude <maxSpeed)
            {
                rb.AddForce(vector * speed);
                anim.SetFloat("Speed", rb.velocity.magnitude / maxSpeed);
            }
            

            if (vector!=Vector3.zero)
            {
                Debug.Log(vector*100);
               
            }
            bool jump = Input.GetKeyDown(KeyCode.Space);
            anim.ResetTrigger("JumpT");
            if (jump)
            {
                Debug.Log("pressed");
                rb.AddForce(0, jumpSpeed, 0);
                //anim.SetTrigger("JumpT");
                anim.SetBool("Jump", true);
            }
            

        }
        else
        {
            //Debug.Log(PlayerManager.instance.GetMainPlayer().gameObject.GetComponentInChildren<inputController2>().pivot.position);
            agent.SetDestination(PlayerManager.instance.player.GetComponentInChildren<inputController2>().pivot.position);
            transform.LookAt(PlayerManager.instance.player.transform);
        }

    }
}