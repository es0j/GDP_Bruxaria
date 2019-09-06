using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
    
    public  CharacterStats playerStats;
    public bool isFighting;
    public Camera camMove;
    public Camera camfight;
    public Canvas fightCanvas;
    public CharacterStats inimigo;
    public void Start()
    {
        Leavefight();
        //playerStats = GetComponent<CharacterStats>();
    }
    public void EnterFight(CharacterStats  inimigoNovo)
    {
        Debug.Log("entrou no conflito.");
        
        inimigo = inimigoNovo;
        Debug.Log(inimigo);
        camMove.enabled = false;
        camfight.enabled = true;
        isFighting = true;
        fightCanvas.enabled = true;
    }
    public void Leavefight()
    {
        isFighting = false;
        camMove.enabled = true;
        camfight.enabled = false;
        fightCanvas.enabled = false;

    }
    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public bool ChangeCurrency(int money)
    {
        Debug.Log(playerStats.gold);
        if (playerStats.gold+money > 0)
        {
            playerStats.gold += money;
            return true;
        }
        return false;
        
    }
}
