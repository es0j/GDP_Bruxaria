using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    public string nome;

    //class that everyone can get, but only characterStats can set
    public int currentHealth { get; private set; }
    public int proeficience;
    public int CA;
    public bool player = false;
    public int[] atributos;
    public int armorClass;
    public int gold=100;
    public bool isAlive = true;
    public int attackPower=0;
    public int defensePower=0;
    public int defenseReductor = 0;

    void Awake()
    {
        currentHealth = maxHealth;
        Inventory.instance.onItemChangedCallback += updateDados;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= Mathf.Clamp(damage-(defensePower- defenseReductor),2,9999);
        if (currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth<=0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        isAlive = false;
        Destroy(gameObject);
    }
    public void updateDados()
    {
        attackPower = 0;
        foreach (Item iten in Inventory.instance.itens)
        {
            attackPower += iten.atackpower;
            defensePower += iten.defensePower;
        }
    }


    public enum Atributos {Forca,Destreza,Const,Sabedoria,Inteligencia,Carisma };
}

