using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagButton : MonoBehaviour,IPointerClickHandler
{

    private Bag bag;
    [SerializeField]
    private Sprite empty, full;

    public Bag ThisBag
    {
        get
        {

            return bag;
        }

        set
        {
            if(value !=null)
            {
                GetComponent<Image>().sprite = full;               
            }
            else
            {
                GetComponent<Image>().sprite = empty;
            }
            bag = value;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                HandScript.Instance.TakeMoveable(ThisBag);
            }
            if (bag != null)
            {
                bag.bagScript.OpenClose();
            }
        }
    }
    public void RemoveBagFromButton()
    {
        InventoryScript.Instance.RemoveBag(ThisBag);
        ThisBag.thisBagButton = null;
        ThisBag = null;
    }
}
