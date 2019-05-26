using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour,IInteractable
{
    [SerializeField]
    private ShopItem[] items;
    [SerializeField]
    private ShopWindow shopWindow;
    public bool isOpen { get; set; }
    public void Interact()
    {
        if(!isOpen)
        {
            isOpen = true;
            shopWindow.CreatePages(items);
            shopWindow.Open(this);
        }
       
    }

    public void StopInteract()
    {
        if (isOpen)
        {
            isOpen = false;
            shopWindow.Close();
        }
    }

 
}
