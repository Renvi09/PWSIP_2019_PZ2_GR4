
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour,IPointerClickHandler,IClicable
{
    private ObservableStack<Item> items = new ObservableStack<Item>();
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text stackSizeText;
    private Item item;
    public bool isEmpty
    {
        get
        {
            return items.Count == 0;
        }
    }

    public Item ThisItem
    {
        get
        {
            if(!isEmpty)
            {
                return items.Peek();
            }
            return null;
        }

      
    }

    public Image ThisIcon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    public int ThisCount
    {
        get
        {
           return items.Count;
        }
    }

    public Text ThisStackText
    {
        get
        {
            return stackSizeText;
        }
    }

    //dodawanie itemu do ekwipunku
    public bool AddItem(Item item)
    {
        items.Push(item);
        icon.sprite = item.Icon;
        icon.color = Color.white;
        item.ThisSlot = this;
        return true;
    }
    public void RemoveItem(Item item)
    {
        if(!isEmpty)
        {
            items.Pop();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       if(eventData.button ==PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }
    public void UseItem()
    {
        if (ThisItem is IUse)
        {
            (ThisItem as IUse).Use();

        }

    }
    private void Awake()
    {
        //przy kazdej zminia stacku itemow dopisana jest fukcja aktualicji stakow 
        items.OnPop += new UpdateStackEvent(UpdatinSlot);
        items.OnPush += new UpdateStackEvent(UpdatinSlot);
        items.OnClear += new UpdateStackEvent(UpdatinSlot);
    }
    private void UpdatinSlot()
    {
        UIManager.Instance.UpdateStackSize(this);
    }
    public bool StackItem(Item item)
    {
        if (!isEmpty&&item.name==ThisItem.name && items.Count<ThisItem.ThisStackSize)
        {
            items.Push(item);
            item.ThisSlot = this;
            return true;
        }
        return false;
    }
}
