using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton

    //same stuff that python POO self.this self.that.Not scared at all.
    public static EquipmentManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance on equipment");
            return;
        }
        instance = this;
    }

    #endregion

    public SkinnedMeshRenderer targetMesh;

    public delegate void OnEquipmentChange(Equipment newItem,Equipment oldItem);
    public OnEquipmentChange onEquipmentChanged;

    Equipment[] currentEquip;
    public Equipment[] deafultItens;
    
    public SkinnedMeshRenderer[] currentMeshes;
    Inventory inventory;


    void Start()
    {
        
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        

        currentEquip = new Equipment[numSlots];
        inventory = Inventory.instance;
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        EquipDefaultItens();
    }

    public void Equip(Equipment newItem)
    {
        //found how to make type converions ,lol same thing as C
        int slotIndex = (int)newItem.equipSlot;
        
        Equipment oldItem = Unequip(slotIndex);
        Debug.Log("item posto na posicao" + slotIndex.ToString());

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        SetEquipmentBlendShapes(newItem, 100);
        currentEquip[slotIndex] = newItem;

        //dress up the player
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;

    }
    public Equipment Unequip(int slotIndex)
    {
        Equipment oldItem=null;
        if (currentEquip[slotIndex]!=null)
        {
            Debug.Log("desequipando "+slotIndex.ToString());
            if (currentMeshes[slotIndex]!=null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            oldItem = currentEquip[slotIndex];
            inventory.Add(oldItem);
            SetEquipmentBlendShapes(oldItem, 0);
            
            
            currentEquip[slotIndex] = null;
            
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            
        }
        return oldItem;

    }
    public void UnequipAll()
    {
        for (int i =0; i< currentEquip.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItens();
    }

    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        // Debug.Log(item.coveredMeshRegions);
        foreach(EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape,weight);
        }
    }
    void EquipDefaultItens()
    {
        foreach(Equipment item in deafultItens)
        {
            Equip(item);
            Debug.Log("equipando " + item.name);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            UnequipAll();
        }
    }

}
