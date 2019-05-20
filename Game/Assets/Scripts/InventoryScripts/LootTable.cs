using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    [SerializeField]
    private Loot[] lootItems;

    private List<Item> dropeditems = new List<Item>();


    public void ShowLoot()
    {
        RollLoot();
        LootWindowScript.Instance.CreatePages(dropeditems);
    }
    private void RollLoot()
    {
        foreach(Loot item in lootItems)
        {
            int roll = Random.Range(0, 100);
            if(roll<=item.ThisDropChance)
            {
                dropeditems.Add(item.ThisItem);
            }
        }
    }
}
