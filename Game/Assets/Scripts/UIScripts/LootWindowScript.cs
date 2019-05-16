using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWindowScript : MonoBehaviour
{
    //debug
    [SerializeField]
    private Item[] items;
    [SerializeField]
    private LootButtonScript[] lootButtons;
    // Start is called before the first frame update
    
    void Start()
    {
        AddLoot();
    }

    private void AddLoot()
    {
        int itemIndex = 1;
        lootButtons[itemIndex].ThisIcon.sprite = items[itemIndex].ThisIcon;
        lootButtons[itemIndex].gameObject.SetActive(true);
        string title = string.Format("<color={0}>{1}</color>", QualityColor.ThisColors[items[itemIndex].ThisQuality],items[itemIndex].ThisTitle);
        lootButtons[itemIndex].ThisTitle.text = title;
        lootButtons[itemIndex].ThisLootItem = items[itemIndex];
    }
}
