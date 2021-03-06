﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootButtonScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text title;
    private LootWindowScript lootWindow;
    public Image ThisIcon
    {
        get
        {
            return icon;
        }

    }

    public Text ThisTitle
    {
        get
        {
            return title;
        }


    }
    public Item ThisLootItem { get; set; }
    private void Awake()
    {
        lootWindow = GetComponentInParent<LootWindowScript>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.ShowTooltip(transform.position, ThisLootItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (InventoryScript.Instance.AddItem(ThisLootItem)) 
        {
            gameObject.SetActive(false);
            lootWindow.TakeLoot(ThisLootItem);
            UIManager.Instance.HideTooltip();
        }
    }
}
