using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : ScriptableObject,IMove,IDescribable
{

    [SerializeField]
    private string title;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int stackSize;
    [SerializeField]
    private Quality quality;
    private SlotScript slotscript;
    public Sprite ThisIcon
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

    public Quality ThisQuality
    {
        get
        {
            return quality;
        }

    }

    public string ThisTitle
    {
        get
        {
            return title;
        }

    }

    public void Remove()
    {
        if (ThisSlot!=null)
        {
            ThisSlot.RemoveItem(this);
        }
    }

    public virtual string GetDescription()
    {
       
       
        return string.Format("<color={0}>{1}</color>",QualityColor.ThisColors[ThisQuality],ThisTitle);
    }
}
