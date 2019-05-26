using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text title;
    [SerializeField]
    private Text price;
    [SerializeField]
    private Text quant;
    private ShopItem shopitem;
    public void AddItem(ShopItem shopItem)
    {
        this.shopitem = shopItem;
        if(shopItem.Quant>0 || shopItem.Unlimited)
        {
            icon.sprite = shopItem.ThisItem.ThisIcon;
            title.text = string.Format("<color={0}>{1}</color>", QualityColor.ThisColors[shopItem.ThisItem.ThisQuality], shopItem.ThisItem.ThisTitle);
           

            if (!shopItem.Unlimited)
            {
                quant.text = shopItem.Quant.ToString();
            }
            {
                quant.text = string.Empty;
            }
            if (shopItem.ThisItem.ThisPrice >0)
            {
                price.text = "Price: " + shopItem.ThisItem.ThisPrice.ToString() + " G";
            }
            else
            {
                price.text = string.Empty;
            }
            gameObject.SetActive(true);
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {
      
            if (PlayerStats.Instance.Gold >= shopitem.ThisItem.ThisPrice && InventoryScript.Instance.AddItem(Instantiate(shopitem.ThisItem)))
            {
               SellItem();
            }
        
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.ShowTooltip(transform.position, shopitem.ThisItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }
    private void SellItem()
    {
        PlayerStats.Instance.Gold -= shopitem.ThisItem.ThisPrice;
        if (!shopitem.Unlimited)
        {
            shopitem.Quant--;
            quant.text = shopitem.Quant.ToString();
            if (shopitem.Quant == 0)
            {
                gameObject.SetActive(false);
                UIManager.Instance.HideTooltip();
            }
        }
      
    }
}
