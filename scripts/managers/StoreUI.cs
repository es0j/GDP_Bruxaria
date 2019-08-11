using UnityEngine;

public class StoreUI : MonoBehaviour
{

    public Transform itemsParent;
    StoreManager store;
    StoreSlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        store = StoreManager.instance;
        //Debug.Log(inventory);
        store.onStoreChangedCallback += UpdateStoreUI;
        slots = itemsParent.GetComponentsInChildren<StoreSlot>();
        gameObject.SetActive(false);

    }


    public void UpdateStoreUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < store.itens.Count)
            {
                slots[i].AddItem(store.itens[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
