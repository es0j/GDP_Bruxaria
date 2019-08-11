using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;
     

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        Debug.Log(inventory);
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        gameObject.SetActive(false);

    }

    
    public void UpdateUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itens.Count)
            {
                slots[i].AddItem(inventory.itens[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
