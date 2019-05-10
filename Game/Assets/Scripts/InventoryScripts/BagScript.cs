using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;
    private CanvasGroup canvasGroup;
    private List<SlotScript> slots = new List<SlotScript>();

    public int ThisEmptySlots
    {
        get
        {

            int count = 0;
            foreach(SlotScript slot in ThisSlots)
            {
                if(slot.isEmpty)
                {
                    count++;
                }
                
            }
            return count;
        }

    }


    public bool IsOpen
    {
        get
        {
            return canvasGroup.alpha>0;
        }

      
    }

    public List<SlotScript> ThisSlots
    {
        get
        {
            return slots;
        }

       
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    //dodaje podana ilosc slotow
    public void AddSlots(int slotNumber)
    {
        for(int i =0;i<slotNumber;i++)
        {
            SlotScript slot = Instantiate(slotPrefab, transform).GetComponent<SlotScript>();
            slot.ThisBagScript = this;
            slots.Add(slot);
        }
    }
    //sprwadza czy moze dodaj item na konkretny slot jesli nie przechodzi dalej
    public bool AddItem(Item item)
    {
        foreach (SlotScript slot in slots)
        {
            if(slot.isEmpty)
            {
                slot.AddItem(item);
                return true;
            }
        }
        return false;
    }
    //zamyaknie i otwierania ekwipunku
    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }
    public List<Item> ReturnItems()
    {
        List<Item> newItems = new List<Item>();
        foreach(SlotScript slot in slots)
        {
            if(!slot.isEmpty)
            {
                foreach(Item item in slot.ThisItems)
                {
                    newItems.Add(item);
                }
                
            }
        }
        return newItems;
    }
}
