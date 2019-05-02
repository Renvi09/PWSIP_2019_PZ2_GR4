using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{

    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int stackSize;

    private SlotScript slotscript;
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    public int StackSize
    {
        get
        {
            return stackSize;
        }        
    }

    public SlotScript Slot
    {
        get
        {
            return slotscript;
        }

        set
        {
            slotscript = value;
        }
    }

}
