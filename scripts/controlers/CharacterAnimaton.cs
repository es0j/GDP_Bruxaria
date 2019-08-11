using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimaton : MonoBehaviour
{
    public NavMeshAgent agent;
    public AnimationClip replacebleAttackAnim;
    public AnimationClip[] defaultAttackAnimationSet;
    protected AnimationClip[] currentAttackAnimSet;

   
    protected Animator animator;
    const float smoothTimeAni = .1f;

    protected CharacterCombat combat;
    public  AnimatorOverrideController overrideControleer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();
        if (overrideControleer==null)
        {
            overrideControleer = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        
        animator.runtimeAnimatorController = overrideControleer;

        currentAttackAnimSet = defaultAttackAnimationSet;

        combat.OnAttack += OnAttack;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        float speedPercent = agent.velocity.magnitude/agent.speed;
        
        animator.SetFloat("Speed",speedPercent, smoothTimeAni, Time.deltaTime);
        animator.SetBool("inCombat", combat.inCombat);
    }


    protected virtual void OnAttack()
    {
        Debug.Log("sobre escrevendo animacao");
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideControleer[replacebleAttackAnim.name] = currentAttackAnimSet[attackIndex];
    }
}
