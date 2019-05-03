using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;
    private CanvasGroup canvasGroup;
    private List<SlotScript> slots = new List<SlotScript>();
  

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
}
