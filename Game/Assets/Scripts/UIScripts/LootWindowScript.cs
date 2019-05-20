using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootWindowScript : MonoBehaviour
{
    private static LootWindowScript instance;
    //zwraca  instancje
    public static LootWindowScript Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<LootWindowScript>();
            }
            return instance;
        }


    }



    [SerializeField]
    private GameObject nextButton, prevButton;
    [SerializeField]
    private Text pageNumberText;
    private List<List<Item>> pages = new List<List<Item>>();
    private int pageIndex=0;
    [SerializeField]
    private LootButtonScript[] lootButtons;
    
       
    void Start()
    {

    }
    public void CreatePages(List<Item> itemList)
    {
        List<Item> page = new List<Item>();
        for (int i = 0; i <itemList.Count; i++)
        {
            page.Add(itemList[i]);
            if(page.Count == 4 || i==itemList.Count -1)
            {
                pages.Add(page);
                page = new List<Item>();
            }
        }
        AddLoot();
    }
    private void AddLoot()
    {
        if(pages.Count >0)
        {
            
            pageNumberText.text = pageIndex + 1 + "/" + pages.Count;

            prevButton.SetActive(pageIndex > 0);
            nextButton.SetActive(pages.Count > 1 && pageIndex<pages.Count -1);

            for (int i = 0; i < pages[pageIndex].Count; i++)
            {
                if(pages[pageIndex][i]!=null)
                {
                    lootButtons[i].ThisIcon.sprite = pages[pageIndex][i].ThisIcon;
                    lootButtons[i].gameObject.SetActive(true);
                    string title = string.Format("<color={0}>{1}</color>", QualityColor.ThisColors[pages[pageIndex][i].ThisQuality], pages[pageIndex][i].ThisTitle);
                    lootButtons[i].ThisTitle.text = title;
                    lootButtons[i].ThisLootItem = pages[pageIndex][i];
                }
             
            }
        }
       
    
    }
    public void ClearButtons()
    {
        foreach (LootButtonScript button in lootButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
    public void NextPage()
    {
        if(pageIndex<pages.Count)
        {
            pageIndex++;
            ClearButtons();
            AddLoot();
        }
    }
    public  void PrevPage()
    {

        if(pageIndex>0)
        {
            pageIndex--;
            ClearButtons();
            AddLoot();
        }
    }
    public void TakeLoot(Item lootItem)
    {
        pages[pageIndex].Remove(lootItem);

        if (pages[pageIndex].Count ==0 )
        {
            pages.Remove(pages[pageIndex]);
            if (pageIndex ==pages.Count && pageIndex >0)
            {
                pageIndex--;
            }
            AddLoot();
        }
    }
    public void OpenClose()
    {

    }
}
