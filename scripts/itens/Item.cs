using UnityEngine;

//alternatives , serialize as json or other stuff

//this allow us to create itens from inventory
[CreateAssetMenu(fileName ="new Item1",menuName ="Inventory/item")]
public class Item : ScriptableObject
{
    //this is a blueprint for itens
    new public string name = "New Item";
    public Sprite icon = null;
    public int selPrice=100;
    public int buyPrice=100;
    public int atackpower = 0;
    public int defensePower = 0;
    public bool isDefaultItem = false;
    public virtual void Use()
    {
        //Debug.Log("item usado"+name);
    }
}
