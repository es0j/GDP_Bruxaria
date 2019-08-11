using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new Item1", menuName = "Inventory/NPC_Talk")]
public class NPC_Talk : ScriptableObject
{
    
    [System.Serializable]
    public struct noTalk
    {
        public string fala;
        public string[] respostas;
        public int[] proximos;
    }
    public noTalk[] grafo;
}
