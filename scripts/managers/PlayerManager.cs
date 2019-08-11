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

    public void Start()
    {
        //playerStats = GetComponent<CharacterStats>();
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
