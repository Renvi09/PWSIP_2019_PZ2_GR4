using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private ShopButton[] shopButton;
    private int pageIndex;
    private List<List<ShopItem>> pages = new List<List<ShopItem>>();
    public void Close()
    {

        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
       
    }

    public void Open()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void AddItems()
    {
        if (pages.Count > 0)
        {
            for (int i = 0; i < pages[pageIndex].Count; i++)
            {
                if (pages[pageIndex][i] != null)
                {
                    shopButton[i].AddItem(pages[pageIndex][i]);
                }
            }
        }
    }
    public void CreatePages(ShopItem[] items)
    {
        List<ShopItem> page = new List<ShopItem>();

        for (int i = 0; i < items.Length; i++)
        {
            page.Add(items[i]);
            if (page.Count == 12 || i == items.Length - 1)
            {
                pages.Add(page);
                page = new List<ShopItem>();
            }
        }
        AddItems();
    }
    public void NextPage()
    {
        if (pageIndex < pages.Count)
        {
            pageIndex++;
         
        }
    }
    public void PrevPage()
    {

        if (pageIndex > 0)
        {
            pageIndex--;
         
        }
    }
}
