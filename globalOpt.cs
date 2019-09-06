using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalOpt : MonoBehaviour
{
    // Start is called before the first frame update
    int friendOpt;
    public Text text;
    public Text text2;
    public CharacterStats friend;
    public CharacterStats enemie;
    int enemieOpt=0;
  

    public void setOptFriend(int opt)
    {

        friendOpt = opt;
    }
    public void go()
    {
        friend = PlayerManager.instance.playerStats;
        enemie = PlayerManager.instance.inimigo;

        if (friend.isAlive==true && enemie.isAlive==true)
        {
            if (friendOpt == 0)
            {
                atackMlee(enemie,friend,true);
            }
            if (friendOpt == 1)
            {
                Witchcraft(enemie, friend,true);
            }
            if (friendOpt == 2)
            {
                magic(enemie, friend,true);
            }

            int num = UnityEngine.Random.Range(0, 2);
            //Debug.Log("inteiro gerado" + num.ToString());
            enemieOpt = num;
            if (enemieOpt== 0)
            {
                atackMlee(friend,enemie);
            }
            if (enemieOpt == 1)
            {
                magic(friend, enemie);
            }
            if (enemieOpt == 3)
            {
                Witchcraft(friend, enemie);
            }



        }
        else
        {
            PlayerManager.instance.Leavefight();
        }
        
        
        
    }
    
    void ShowString(string display,bool show)
    {
        if (show)
        {
            Debug.Log("rodando display");
            text.text = display;
            //yield return new WaitForSeconds(2f);
        }
        else
            text2.text = display;

    }
    void atackMlee(CharacterStats p1, CharacterStats p2,bool show=false)
    {
        Debug.Log("rodando mlee");
        int num = UnityEngine.Random.Range(0, 20);
        if (num + p2.attackPower > p1.CA + p2.defensePower)
        {
            int damage= UnityEngine.Random.Range(0, 8);
            p1.TakeDamage(damage);
            
            ShowString("Voce rolou : "+num.ToString()+"  de 20. \nACERTO: "+ (num + p2.attackPower).ToString() + "\n Ataque bem sucedido! "+p1.nome+" levou "+damage.ToString()+"/8 de dano!", show);
            
        }
        else
        {
            ShowString("Voce rolou : " + num.ToString() + "  de 20 \n"+(num + p2.attackPower).ToString() + " Não foi o suficiente para atingir o inimigo!!\n " + p1.nome + " nao levou  dano", show);
        }


    }
    void Witchcraft(CharacterStats p1, CharacterStats p2, bool show = false)
    {
        Debug.Log("rodando witchcraft");
        int num = UnityEngine.Random.Range(0, 20);
        if (true)
        {
            int damage = UnityEngine.Random.Range(0, 8);
            p1.defenseReductor += damage;

            ShowString(p1.nome +" teve sua armadura reduzida em " + damage.ToString() + " pontos!", show);
            
        }
       


    }
    void magic(CharacterStats p1, CharacterStats p2, bool show = false)
    {
        Debug.Log("cura");
        
        if (true)
        {
            int damage = UnityEngine.Random.Range(0, 10);
            p2.TakeDamage(-damage);

            ShowString("Cura realizada: "+ p2.name + " curou um total de " + damage.ToString() + "pontos de vida!", show);
            
        }
        


    }
}
