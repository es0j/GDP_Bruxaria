using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(CapsuleCollider))]

public class newControler : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public float m_Speed=1;
    public float turnSpeed = 100f;
    public Transform pivot;
    Vector3 move;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();


        move = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, 1, 0), -Time.deltaTime * turnSpeed);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, 1, 0), Time.deltaTime * turnSpeed);
        
        if (Input.GetKey(KeyCode.W))
        {
            move = transform.forward * m_Speed * Time.deltaTime;
            agent.Move(move);
        }

        if (Input.GetKey(KeyCode.S))
        {
            move = -transform.forward * m_Speed*Time.deltaTime;
            agent.Move(move);
        }
       
        anim.SetFloat("Speed", Mathf.Clamp(  Mathf.Abs( move.magnitude)*100f / agent.speed,0,1));
    }
}
