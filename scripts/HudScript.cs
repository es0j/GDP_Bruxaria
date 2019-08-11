using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    Text myText;
    CharacterStats player;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        player = PlayerManager.instance.playerStats;
    }
    IEnumerator updateUI()
    {
        string hud = "";
        hud += player.name+"\n";
        hud += "vida: "+player.currentHealth.ToString()+"/"+ player.maxHealth.ToString()+"\n";
        hud += "gold: " + player.gold.ToString() + "\n";
       
        myText.text = hud;
        yield return new WaitForSeconds(0.1f);
    }

    // DELETE THIS ASAP dirty non optimal stuff down here. preffere use delegates
    void Update()
    {
        StartCoroutine(updateUI());   
    }
}
