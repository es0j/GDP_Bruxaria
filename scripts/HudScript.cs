using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    public bool isPlayer;
    Text myText;
    Text myText2;
    CharacterStats player;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        
    }
    IEnumerator updateUI()
    {
        if (isPlayer)
            player = PlayerManager.instance.playerStats;
        else
            player = PlayerManager.instance.inimigo;

        if (PlayerManager.instance.isFighting || isPlayer)
        {
            if (player != null)
            {
                string hud = "";
                hud += player.nome + "\n";
                hud += "vida: " + player.currentHealth.ToString() + "/" + player.maxHealth.ToString() + "\n";
                hud += "gold: " + player.gold.ToString() + "\n";
                hud += "Poder de ataque: " + player.attackPower.ToString()+"\n";
                hud += "Poder de defesa: " + (player.defensePower-player.defenseReductor ).ToString() + "\n";
                myText.text = hud;
            }
            else
                myText.text = "";
        }
        else
        {
            myText.text = "";
        }

        yield return new WaitForSeconds(0.1f);
    }

    // DELETE THIS ASAP: dirty non optimal stuff down here. preffere to use delegates
    void Update()
    {
        StartCoroutine(updateUI());   
    }
}
