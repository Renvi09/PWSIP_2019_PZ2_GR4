﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
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
    //sprwadza czy limit bagow zostal spelniony
    public bool CanAddBags
    {
        get
        {
            return bags.Count < 4;
        }

    }

    [SerializeField]
    private Item[] items;
    [SerializeField]
    private BagButton[] bagButtons;
    private List<Bag> bags = new List<Bag>();
    // Start is called before the first frame update
    private void Awake()
    {
        Bag bag = (Bag)Instantiate(items[0]);
        bag.Slots = 16;
        bag.Use();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Bag bag = (Bag)Instantiate(items[0]);
            bag.Slots = 16;
            bag.Use();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Bag bag = (Bag)Instantiate(items[0]);
            bag.Slots = 16;
            AddItem(bag);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            HpPot pot = (HpPot)Instantiate(items[1]);
          
            AddItem(pot);
        }
    }
    //dodaje bag do listy bagow 
    public void AddBag(Bag bag)
    {
        foreach(BagButton bagButton in bagButtons)
        {
            if (bagButton.Bag == null)
            {
                bagButton.Bag = bag;
                bags.Add(bag);
                break;
            }
        }
    }
    //sprwdza czy jest miescie dla itemu 
    private void PlaceInEmpty(Item item)
    {
        foreach (Bag bag in bags)
        {
            if(bag.bagScript.AddItem(item))
            {
                return;
            }
        }
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
                    return true;
                }
            }
        }
        return false;
    }
    //sprwadza czy moze dodaj item do konkrengo baga jesli nie przechodzi dalej
    public void AddItem(Item item)
    {
        if (item.ThisStackSize > 0)
        {
            if (CanStack(item))
            {
                return;
            }

        }
        PlaceInEmpty(item);
    }
    public void OpenCloseInventory()
    {
        //if True otwiera wszytkie bagi
        //if flase zamyka wszytkie bagi
        bool closedBad = bags.Find(x => !x.bagScript.IsOpen);
        foreach(Bag bag in bags)
        {
            if(bag.bagScript.IsOpen!=closedBad)
            {
                bag.bagScript.OpenClose();
            }
        }
    }
}
