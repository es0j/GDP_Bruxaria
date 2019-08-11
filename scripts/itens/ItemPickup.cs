using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    //override is used to override virtual functions
    public override void Interact()
    {

        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        //dont use find Object of type
        //Debug.Log("coletado "+ item.name);
        if (Inventory.instance.Add(item))
        {
            Destroy(gameObject);
        }
        
    }
}
