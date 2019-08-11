using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellaNPC : NPC
{
    [SerializeField]
    public QuestType.Quest q1;
    

    public override void NpcCallBack(int grafoIndice)
    {
        if (grafoIndice == -1)
        {
            QuestManager.instance.Add(q1);
        }
        

    }
}
