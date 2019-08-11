using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    //i guess the statement 'new' means to initialize the constructure of list ?? like c++?

    //just to leave code beauty
    #region Singleton

    //same stuff that python POO self.this self.that.Not scared at all.
    public static Inventory instance;
    void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("more than one instance of inventory");
            return;
        }
        instance = this;
    }

    #endregion

    //subscrive and publish system aparantely
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject inventoryUI;
    
    InventoryUI inventoryUIScript;

    public int space = 3;
     

    public List<Item> itens = new List<Item>();

    public void Start()
    {
        inventoryUIScript = inventoryUI.GetComponent<InventoryUI>();
        //mirror.SetActive(false);
    }

    public bool Add(Item item)
    {
        if (item != null)
        {
            if (!item.isDefaultItem && itens.Count < space)
            {
                itens.Add(item);
                //if has subscriptions
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                //Debug.Log(onItemChangedCallback.ToString());

                return true;
            }
            //Debug.Log("sem espaco");

        }

        return false;
    }

    public void Remove(Item item)
    {
        itens.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            //mirror.SetActive(!mirror.activeSelf);
            //inventoryUI.GetComponent<InventoryUI>().UpdateUI();
        }
    }


}
