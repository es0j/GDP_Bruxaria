using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipement",menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public SkinnedMeshRenderer mesh;
    public EquipmentSlot equipSlot;
    public EquipmentMeshRegion[] coveredMeshRegions;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        Inventory.instance.Remove(this);

    }
}

public enum EquipmentSlot
{ Head,Chest,Legs,WeaponL,WeaponR,Sheld,Feet,Ring};

public enum EquipmentMeshRegion
{ Legs, Arm,Torso,head };