using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimaton
{
    public WeaponAnimatons[] weaponAnim;
    Dictionary<Equipment, AnimationClip[]> weaponAnimationsDict;

    protected override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        weaponAnimationsDict = new Dictionary<Equipment, AnimationClip[]>();
        foreach (WeaponAnimatons a in weaponAnim)
        {
            weaponAnimationsDict.Add(a.weapon, a.clips);
        }
    }
    // Start is called before the first frame update
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem!=null && newItem.equipSlot == EquipmentSlot.WeaponR)
        {
            animator.SetLayerWeight(1, 1);
            if (weaponAnimationsDict.ContainsKey(newItem))
            {
                currentAttackAnimSet = weaponAnimationsDict[newItem];
            }
        }
        else if (newItem == null && oldItem!=null && oldItem.equipSlot==EquipmentSlot.WeaponR)
        {
            animator.SetLayerWeight(1, 0);
            currentAttackAnimSet = defaultAttackAnimationSet;
        }

        if (newItem != null && newItem.equipSlot == EquipmentSlot.WeaponL)
        {
            animator.SetLayerWeight(2, 1);
        }
        else if (newItem == null && oldItem != null && oldItem.equipSlot == EquipmentSlot.WeaponL)
        {
            animator.SetLayerWeight(2, 0);
        }
    }
    [System.Serializable]
    public struct WeaponAnimatons
    {
        public Equipment weapon;
        public AnimationClip[] clips;
    }
}
