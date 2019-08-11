using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Item1", menuName = "Inventory/QuestType")]
public class QuestType : ScriptableObject
{

    [System.Serializable]
    public struct Quest
    {
        public List<string> todo;
        public List<bool> todoStats;
    }
    public Quest questObj ;

}
