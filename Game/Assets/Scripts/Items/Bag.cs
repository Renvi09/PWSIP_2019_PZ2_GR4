
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Bag",menuName ="Items/Bag",order =1)]
public class Bag : Item, IUse
{
    private int slots;
    [SerializeField]
    private GameObject bagPrefab;

    public BagScript bagScript { get; set; }
    public BagButton thisBagButton { get; set; }
    public int Slots
    {
        get
        {
            return slots;
        }

        set
        {
            slots = value;
        }
    }
    public void Use()
    {
        if (InventoryScript.Instance.CanAddBags)
        {
            Remove();
            bagScript = Instantiate(bagPrefab, InventoryScript.Instance.transform).GetComponent<BagScript>();
            bagScript.AddSlots(slots);
            InventoryScript.Instance.AddBag(this);
        }
    }
}
