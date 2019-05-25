using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour,IInteractable
{
    [SerializeField]
    private ShopWindow shopWindow;
    public void Interact()
    {
        shopWindow.Open();
    }

    public void StopInteract()
    {
        shopWindow.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
