
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour, IPointerClickHandler
{
    public IUse ThisIUse { get; set; }
    public Button ThisButton { get; private set; }

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

    [SerializeField]
    private Image icon;
    // Start is called before the first frame update
    void Start()
    {
        ThisButton = GetComponent<Button>();
        ThisButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        if (ThisIUse != null)
        {
            ThisIUse.Use();
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
    
        this.ThisIUse = useable;
        UpdateVisual();
    }
    public void UpdateVisual()
    {
        ThisIcon.sprite = HandScript.Instance.Put().ThisIcon;
        ThisIcon.color= Color.white;
    }
}
