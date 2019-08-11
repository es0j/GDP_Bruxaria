using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    //i guess the statement 'new' means to initialize the constructure of list ?? like c++?

    //just to leave code beauty
    #region Singleton

    //same stuff that python POO self.this self.that.Not scared at all.
    public static StoreManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory");
            return;
        }
        instance = this;
    }

    #endregion

    //subscrive and publish system aparantely
    public delegate void OnStoreChanged();
    public OnStoreChanged onStoreChangedCallback;
    public GameObject storeUi;

    StoreUI storeUiScript;

    //public int space = 3;


    public List<Item>  itens;

    public void Start()
    {
        storeUiScript = storeUi.GetComponent<StoreUI>();
        
    }
    public void SetItens(List<Item> itemList)
    {
        itens = itemList;
        if(onStoreChangedCallback!=null)
        {
            onStoreChangedCallback.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed");
            storeUi.SetActive(!storeUi.activeSelf);
            //mirror.SetActive(!mirror.activeSelf);
            //inventoryUI.GetComponent<InventoryUI>().UpdateUI();
        }
    }





}
