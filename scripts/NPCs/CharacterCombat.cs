using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    public float attackSpeed=1f;
    private float attackCooldown = 0f;
    public float atackDelay=.5f;

    const float combatCooldown = 5;
    float lastAttackTime;
    public bool inCombat { get; private set; }

    //void delegate
    public event System.Action OnAttack;


    CharacterStats myStats;
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
        }
    }
    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown<=0f)
        {
            StartCoroutine(DoDamage(targetStats,atackDelay));
            //targetStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
            if (OnAttack != null)
            {
                OnAttack();
            }
        }
        
        inCombat = true;
        lastAttackTime = Time.time;

        
    }
    IEnumerator DoDamage(CharacterStats stats,float delay)
    {
        yield return new WaitForSeconds(delay);
        //stats.TakeDamage(myStats.damage.GetValue());
        if (stats.currentHealth<=0)
        {
            inCombat = false;
        }
    }
}
