using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private static InventoryScript instance;

    public static InventoryScript Instance
    {
        get
        {
            
            if(instance==null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }
            return instance;
        }

       
    }

    public bool CanAddBags
    {
        get
        {
            return bags.Count < 4;
        }

    }

    [SerializeField]
    private Item[] items;
    [SerializeField]
    private BagButton[] bagButtons;
    private List<Bag> bags = new List<Bag>();
    // Start is called before the first frame update
    private void Awake()
    {
        Bag bag = (Bag)Instantiate(items[0]);
        bag.Slots = 16;
        bag.Use();

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Bag bag = (Bag)Instantiate(items[0]);
            bag.Slots = 16;
            bag.Use();
        }
    }
    public void AddBag(Bag bag)
    {
        foreach(BagButton bagButton in bagButtons)
        {
            if (bagButton.Bag == null)
            {
                bagButton.Bag = bag;
                bags.Add(bag);
                break;
            }
        }
    }
    public void OpenCloseInventory()
    {
        //if True otwiera wszytkie bagi
        //if flase zamyka wszytkie bagi
        bool closedBad = bags.Find(x => !x.bagScript.IsOpen);
        foreach(Bag bag in bags)
        {
            if(bag.bagScript.IsOpen!=closedBad)
            {
                bag.bagScript.OpenClose();
            }
        }
    }
}
