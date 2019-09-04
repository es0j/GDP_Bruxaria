using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;
    //override is used to override virtual functions
    //private Vector3 player;
    //private Vector3 distance2;

    playerController playerC;
    
    public override void Interact()
    {

        base.Interact();
        PickUp();
    }
    public override void HasRange()
    {
        playerC = PlayerManager.instance.player.GetComponent<playerController>();
        playerC.ShowPopUp(transform.GetComponent<Interactable>(), item);
        
    }
    /*public override void HasNOTRange()
    {
        
        playerC.HidePopUp();

    }*/
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
