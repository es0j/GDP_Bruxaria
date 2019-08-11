using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : NPC
{
    InventoryUI storeUIScript;
    public List<Item> itens;// = new List<Item>();
    //override is used to override virtual functions
    public override void Interact()
    {

        base.Interact();
        
    }
    public override void DialogueStart()
    {
        base.DialogueStart();
        StoreManager.instance.SetItens(itens);
        StoreManager.instance.storeUi.SetActive(true);
        
        
    }

    public override void NpcCallBack(int grafoIndice)
    {
        if(grafoIndice==-1)
        {
            StoreManager.instance.storeUi.SetActive(false);
        }
        base.NpcCallBack(grafoIndice);
        Debug.Log("bem vindo a lojaa");
        
    }
    public  void NpcOnCLickCallBack()
    {
        

    }
}
