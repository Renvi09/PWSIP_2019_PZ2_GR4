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
    public void AddItem(ShopItem shopItem)
    {
        if(shopItem.Quant>0 || shopItem.Unlimited)
        {
            icon.sprite = shopItem.ThisItem.ThisIcon;
            title.text = string.Format("<color={0}>{1}</color>", QualityColor.ThisColors[shopItem.ThisItem.ThisQuality], shopItem.ThisItem.ThisTitle);
            price.text = "Price: " + shopItem.ThisItem.ThisPrice.ToString() + " G";

            if (!shopItem.Unlimited)
            {
                quant.text = shopItem.Quant.ToString();
            }
            gameObject.SetActive(true);
        }

    }
    public void OnPointerClick(PointerEventData eventData)
    {
    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
 
    }
}
