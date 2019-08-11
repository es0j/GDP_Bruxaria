using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;
    
    Item item;

    public void AddItem(Item newItem)
    {
        Debug.Log(newItem.icon);
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }
    
    public void UseItem()
    {
        
        if (PlayerManager.instance.ChangeCurrency(-item.buyPrice))
        {
            Inventory.instance.Add(item);
            ClearSlot();
        }
        //code to buy item

    }

}
