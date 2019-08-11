using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stat
{
    //can be acessed from editor
    [SerializeField]
    private int baseValue=0;

    private List<int> modifiers = new List<int>();


    public int GetValue()
    {
        int finalValue = baseValue;
        //lol, same thinf [x for x in lista] of python
        modifiers.ForEach(x => finalValue += x);
        
        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        
        if(modifier!=0)
        {
            modifiers.Add(modifier);
        }
        
    }
    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }

    }
}
