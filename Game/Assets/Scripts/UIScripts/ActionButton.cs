
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour, IPointerClickHandler, IClicable,IPointerEnterHandler, IPointerExitHandler
{
    public IUse ThisIUse { get; set; }
    public Button ThisButton { get; private set; }
    private Stack<IUse> useables = new Stack<IUse>();
    private int count;
    [SerializeField]
    private Text stackSize;

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
            return count;
        }
    }

    public Text ThisStackText
    {
        get
        {
            return stackSize;
        }
    }

    public Stack<IUse> Useables
    {
        get
        {
            return Useables1;
        }

        set
        {
            Useables1 = value;
        }
    }

    public Stack<IUse> Useables1
    {
        get
        {
            return useables;
        }

        set
        {
            ThisIUse = value.Peek();
            useables = value;
        }
    }

    [SerializeField]
    private Image icon;
    // Start is called before the first frame update
    void Start()
    {
        ThisButton = GetComponent<Button>();
        ThisButton.onClick.AddListener(OnClick);
        InventoryScript.Instance.itemCountChangedEvent += new ItemCountChanged(UpdateItemCount);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        if (HandScript.Instance.ThisMove == null)
        {
            if (ThisIUse != null)
            {
                ThisIUse.Use();
            }
            if(Useables != null && Useables.Count >0)
            {
                Useables.Peek().Use();
            }
        }
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (HandScript.Instance.ThisMove != null && HandScript.Instance.ThisMove is IUse )
            {
                SetUsable(HandScript.Instance.ThisMove as IUse);
            }
        }

    }
    public void SetUsable(IUse useable)
    {
        if (useable is Item)
        {
            Useables = InventoryScript.Instance.GetUsables(useable);
            count = Useables.Count;
            InventoryScript.Instance.FromSlot.ThisIcon.color = Color.white;
            InventoryScript.Instance.FromSlot = null;

        }
        else
        {
            this.ThisIUse = useable;
          
        }
        count = Useables.Count;
        UpdateVisual();
        
    }
    public void UpdateVisual()
    {
        ThisIcon.sprite = HandScript.Instance.Put().ThisIcon;
        ThisIcon.color= Color.white;
        if(count>1)
        {
            UIManager.Instance.UpdateStackSize(this);
        }
    }
    public void UpdateItemCount(Item item)
    {
       if(item is IUse &&Useables.Count >0)
        {
          if(Useables.Peek().GetType()==item.GetType() )
            {
                Useables = InventoryScript.Instance.GetUsables(item as IUse);
                count = Useables.Count;
                UIManager.Instance.UpdateStackSize(this);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
     if(ThisIUse!=null )
        {
            UIManager.Instance.ShowTooltip(transform.position,(IDescribable)ThisIUse);
        }
        else if (Useables.Count>0)
        {
            UIManager.Instance.ShowTooltip(transform.position, (IDescribable)ThisIUse);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.HideTooltip();
    }
}
