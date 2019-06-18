
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IPointerClickHandler, IClicable,IPointerEnterHandler,IPointerExitHandler
{
    private ObservableStack<Item> items = new ObservableStack<Item>();
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text stackSizeText;
    private Item item;
    public BagScript ThisBagScript { get; set; }
    public bool isEmpty
    {
        get
        {
            return items.Count == 0;
        }
    }
    public bool isFull
    {
        get
        {

            if (isEmpty || ThisCount < ThisItem.ThisStackSize)
            {
                return false;
            }
            return true;

        }
    }



    public Item ThisItem
    {
        get
        {
            if (!isEmpty)
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

    public ObservableStack<Item> ThisItems
    {
        get
        {
            return items;
        }
    }

    //dodawanie itemu do ekwipunku
    public bool AddItem(Item item)
    {
        items.Push(item);
        icon.sprite = item.ThisIcon;
        icon.color = Color.white;
        item.ThisSlot = this;
        return true;
    }
    public void RemoveItem(Item item)
    {
        if (!isEmpty)
        {           
            InventoryScript.Instance.OnItemCountChanged(items.Pop());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //jesli reka jest pusta podnosci item z eq 
            if (InventoryScript.Instance.FromSlot == null && !isEmpty)
            {
                HandScript.Instance.TakeMoveable(ThisItem as IMove);
                InventoryScript.Instance.FromSlot = this;
            }
            else if (InventoryScript.Instance.FromSlot == null && isEmpty && (HandScript.Instance.ThisMove is Bag))
            {
                Bag bag = (Bag)HandScript.Instance.ThisMove;
                if (bag.bagScript!= ThisBagScript && InventoryScript.Instance.ThisEmptySlots - bag.Slots >0)
                {
                    AddItem(bag);
                    bag.thisBagButton.RemoveBagFromButton();
                    HandScript.Instance.Drop();
                }

               
            }
            //jesli jest cos na rece odklada go
            else if (InventoryScript.Instance.FromSlot != null)
            {
                if (PutItemBack()||MergeItems(InventoryScript.Instance.FromSlot) ||SwapItems(InventoryScript.Instance.FromSlot) || AddItems(InventoryScript.Instance.FromSlot.items))
                {
                    HandScript.Instance.Drop();
                    InventoryScript.Instance.FromSlot = null;
                }
            }
        }
        if (eventData.button == PointerEventData.InputButton.Right)
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
        //przypisanie dodakowych fukcji stakowi itemo przy aktualizacji
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
        if (!isEmpty && item.name == ThisItem.name && items.Count < ThisItem.ThisStackSize)
        {
            items.Push(item);
            item.ThisSlot = this;
            return true;
        }
        return false;
    }
    private bool PutItemBack()
    {
        if (InventoryScript.Instance.FromSlot == this)
        {
            InventoryScript.Instance.FromSlot.ThisIcon.color = Color.white;
            return true;
        }
        return false;
    }
    public bool AddItems(ObservableStack<Item> newItems)
    {
        //sprwadza czy slot jest pusty lub jest tego samego typu 
        if (isEmpty || newItems.Peek().GetType() == ThisItem.GetType())
        {
            int count = newItems.Count;
            for (int i = 0; i < count; i++)
            {

                if (isFull)
                {
                    return false;
                }
                AddItem(newItems.Pop());
            }
            return true;
        }
        return false;
    }
    private bool SwapItems(SlotScript from)

    {
        if (isEmpty)
        {
            return false;
        }
        //zamienia miejscami przedmioty
        if(from.ThisItem.GetType() != ThisItem.GetType() ||from.ThisItem.name !=ThisItem.name ||from.ThisCount+ThisCount>ThisItem.ThisStackSize)
        {
            //kopijujem itemy do tempa z slota do zmany A
            ObservableStack<Item> tmpFrom = new ObservableStack<Item>(from.items);
            //czyscimy slot od zmiany
            from.items.Clear();
            //dodajemy itemy do drugigo slotu do zmiany
            //Same B
            from.AddItems(items);
            items.Clear();
            AddItems(tmpFrom);
            return true;
        }
        return false;
    }
    private bool MergeItems(SlotScript from)
    {
        if (isEmpty || from.ThisItem.name !=ThisItem.name)
        {
            return false;
        }
        if(from.ThisItem.GetType() == ThisItem.GetType() && !isFull)
        {
            int freeSlots = ThisItem.ThisStackSize - ThisCount;
            for (int i = 0; i < freeSlots; i++)
            {
                AddItem(from.items.Pop());
            }
            return true;
        }
        return false;
    }
    public void Clear()
    {
        int iniCount = ThisItems.Count;
        if(items.Count>0)
        {
            for (int i = 0; i < iniCount; i++)
            {
                InventoryScript.Instance.OnItemCountChanged(items.Pop());
            }
           
           
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isEmpty)
        {
            UIManager.Instance.ShowTooltip(transform.position,ThisItem);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }
}
