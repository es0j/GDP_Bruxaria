using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    

    //class that everyone can get, but only characterStats can set
    public int currentHealth { get; private set; }
    public int proeficience;
    public int CA;
    public bool player = false;
    public int[] atributos;
    public int armorClass;
    public int gold=100;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {

    }
    public virtual void Die()
    {
        //here we die;
    }



    public enum Atributos {Forca,Destreza,Const,Sabedoria,Inteligencia,Carisma };
}

