using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private GameObject nextButton, prevButton;
    [SerializeField]
    private ShopButton[] shopButton;
    private int pageIndex;
    private List<List<ShopItem>> pages = new List<List<ShopItem>>();
    [SerializeField]
    private Text pageNumber;

    private Shop shop;
    public void Close()
    {
     
        shop.isOpen = false;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        ClearButtons();
        shop = null;
       
    }

    public void Open(Shop shop)
    {
       
        this.shop = shop;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void AddItems()
    {
        pageNumber.text = pageIndex + 1 + "/" + pages.Count;
        prevButton.SetActive(pageIndex > 0);
        nextButton.SetActive(pages.Count > 1 && pageIndex < pages.Count - 1);
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
        pages.Clear();
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
            ClearButtons();
            AddItems();
        }
    }
    public void PrevPage()
    {

        if (pageIndex > 0)
        {
            pageIndex--;
            ClearButtons();
            AddItems();
        }
    }
    public void ClearButtons()
    {
        foreach (ShopButton button in shopButton)
        {
            button.gameObject.SetActive(false);
        }
    }
}
