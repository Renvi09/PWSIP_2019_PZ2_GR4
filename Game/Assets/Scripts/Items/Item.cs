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

    public int ThisStackSize
    {
        get
        {
            return stackSize;
        }        
    }

    public SlotScript ThisSlot
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
    public void Remove()
    {
        if (ThisSlot!=null)
        {
            ThisSlot.RemoveItem(this);
        }
    }
}
