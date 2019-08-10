using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject mainPlayer;
    public List<Transform> partyMembers;
    public Transform party;
    
    
    // Start is called before the first frame update
    void Start()
    {
        OnPartyChanged();
    }

    // Update is called once per frame
    void Update()
    {
        OnPartyChanged();
    }

    void OnPartyChanged()
    {
        partyMembers.Clear();
        foreach (Transform child in party)
        {
            if (child.tag == "Player")
            {
                partyMembers.Add(child.transform);
            }
        }
    }

}