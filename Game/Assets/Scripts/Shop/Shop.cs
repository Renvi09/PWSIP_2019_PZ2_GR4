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
    public void Interact()
    {
        shopWindow.CreatePages(items);
        shopWindow.Open();
    }

    public void StopInteract()
    {
        shopWindow.Close();
    }

 
}
