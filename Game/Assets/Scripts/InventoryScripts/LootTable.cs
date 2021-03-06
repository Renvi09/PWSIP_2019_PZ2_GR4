﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    [SerializeField]
    private Loot[] lootItems;

    private List<Item> dropeditems = new List<Item>();
    private bool droped = false;

    public void ShowLoot()
    {
        if(!droped)
        {
            RollLoot();
        }
     
        LootWindowScript.Instance.CreatePages(dropeditems);
       
    }
    private void LateUpdate()
    {
        if (droped && dropeditems.Count == 0)
        {
            LootWindowScript.Instance.Close();
            Destroy(this.gameObject);
           
        }
    }
    private void RollLoot()
    {
        foreach(Loot item in lootItems)
        {
            int roll = Random.Range(0, 100);
            if(roll<=item.ThisDropChance)
            {
                dropeditems.Add(Instantiate(item.ThisItem));
            }
          
        }
        droped = true;
    }
}
