using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfigs : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton

    //same stuff that python POO self.this self.that.Not scared at all.
    public static GlobalConfigs instance;
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

    public int ENEMY_LIFE_MODIFIER=1;
}
