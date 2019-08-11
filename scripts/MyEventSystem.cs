using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MyEventSystem : MonoBehaviour
{
    //fix me and do it properly. handle quest completion in the quest objects please.
    //hurry
    public int enemiesKilled;

    #region Singleton

    //same stuff that python POO self.this self.that.Not scared at all.
    public static MyEventSystem instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance on DialogueManager");
            return;
        }
        instance = this;
    }

    #endregion

    public void AddScoreCount()
    {
        enemiesKilled += 1;
        if (enemiesKilled>=7)
        {

            Debug.Log("FIM DE JOGOOO");
            SceneManager.LoadScene("02", LoadSceneMode.Single);
        }
    }

}
