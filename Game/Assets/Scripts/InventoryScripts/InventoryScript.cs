﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void ItemCountChanged(Item item);
public class InventoryScript : MonoBehaviour
{
    public event ItemCountChanged itemCountChangedEvent;
    private static InventoryScript instance;
    //zwraca  instancje
    public static InventoryScript Instance
    {
        get
        {
            
            if(instance==null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }
            return instance;
        }

       
    }
    public int ThisEmptySlots
    {
        get
        {
            int count = 0;
            foreach(Bag bag in bags)
            {
                count += bag.bagScript.ThisEmptySlots;
            }
           
            return count;
        }
    }
    private SlotScript fromSlot;

    //sprwadza czy limit bagow zostal spelniony
    public bool CanAddBags
    {
        get
        {
            return bags.Count < 4;
        }

    }

    public SlotScript FromSlot
    {
        get
        {
            return fromSlot;
        }

        set
        {
            fromSlot = value;
            if (value != null)
            {
                fromSlot.ThisIcon.color = Color.grey;
            }
            fromSlot = value;
        }
    }

    [SerializeField]
    private Item[] items;
    [SerializeField]
    private BagButton[] bagButtons;
    private List<Bag> bags = new List<Bag>();
    // Start is called before the first frame update
    private void Start()
    {
        OpenCloseInventory();
    }
    private void Awake()
    {
        Bag bag = (Bag)Instantiate(items[0]);
        bag.Slots = 16;
        bag.Use();
      

    }
  
    //dodaje bag do listy bagow 
    public void AddBag(Bag bag)
    {
        foreach(BagButton bagButton in bagButtons)
        {
            if (bagButton.ThisBag == null)
            {
                bagButton.ThisBag = bag;
                bags.Add(bag);
                bag.thisBagButton = bagButton;
                bag.bagScript.transform.SetSiblingIndex(bagButton.BagIndex);
                break;
            }
        }
    }
    //sprwdza czy jest miescie dla itemu 
    private bool PlaceInEmpty(Item item)
    {
        foreach (Bag bag in bags)
        {
            if(bag.bagScript.AddItem(item))
            {
                OnItemCountChanged(item);
                return true;
            }
        }
        return false;
    }
    //sprwadza czy jest miescie dla itemu w stacku 
    private bool CanStack(Item item)
    {
        foreach(Bag bag in bags)
        {
            foreach(SlotScript slot in bag.bagScript.ThisSlots)
            {
                if(slot.StackItem(item))
                {
                    OnItemCountChanged(item);
                    return true;
                }
            }
        }
        return false;
    }
    //sprwadza czy moze dodaj item do konkrengo baga jesli nie przechodzi dalej
    public bool AddItem(Item item)
    {
        if (item.ThisStackSize > 0)
        {
            if (CanStack(item))
            {
                return true;
            }
            
        }
        return PlaceInEmpty(item);
    }
    public void OpenCloseInventory()
    {
        //if True otwiera wszytkie bagi
        //if flase zamyka wszytkie bagi
        bool closedBad = bags.Find(x => !x.bagScript.IsOpen);
        foreach (Bag bag in bags)
        {
            if (bag.bagScript.IsOpen != closedBad)
            {
                bag.bagScript.OpenClose();
            }
        }
    }
    public void RemoveBag(Bag bag)
    {
        bags.Remove(bag);
        Destroy(bag.bagScript.gameObject);
    }
    public Stack<IUse> GetUsables(IUse type)
    {
        Stack<IUse> useables = new Stack<IUse>();
        foreach(Bag bag in bags)
        {
            foreach(SlotScript slot in bag.bagScript.ThisSlots)
            {
                if(!slot.isEmpty && slot.ThisItem.GetType() == type.GetType() )
                {
                    foreach(Item item in slot.ThisItems)
                    {
                        useables.Push(item as IUse);
                    }
                   
                }
            }
        }
        return useables;
    }
    public void OnItemCountChanged(Item item)
    {
        if (itemCountChangedEvent != null)
        {
            itemCountChangedEvent.Invoke(item);
        }

    }
    public int GetItemCount(string type)
    {
        int itemCount = 0;
        foreach(Bag bag in bags)
        {
            foreach (SlotScript slot in bag.bagScript.ThisSlots)
            {
                if(!slot.isEmpty && slot.ThisItem.ThisTitle.ToLower() ==type.ToLower())
                {
                    itemCount += slot.ThisItems.Count;
                }
            }
        }
        return itemCount;
    }
    public Stack<Item> GetItems(string type,int count)
    {
        Stack<Item> items = new Stack<Item>();
        foreach (Bag bag in bags)
        {
            foreach (SlotScript slot in bag.bagScript.ThisSlots)
            {
                if (!slot.isEmpty && slot.ThisItem.ThisTitle.ToLower() == type.ToLower())
                {
                    foreach (Item item in slot.ThisItems)
                    {
                        items.Push(item);
                        if(items.Count==count)
                        {
                            return items;
                        }
                    }
                }
            }
        }
        return items;
    }
}
