using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShopItem
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private int quant;
    [SerializeField]
    private bool unlimited;

    public Item ThisItem
    {
        get
        {
            return item;
        }
    }

    public int Quant
    {
        get
        {
            return quant;
        }

        set
        {
            quant = value;
        }
    }

    public bool Unlimited
    {
        get
        {
            return unlimited;
        }
    }
}
