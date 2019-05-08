using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandScript : MonoBehaviour
{
    private static HandScript instance;
    //zwraca  instancje
    public static HandScript Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<HandScript>();
            }
            return instance;
        }


    }
    public IMove ThisMove { get; set; }
    private Image ThisIcon;

    // Start is called before the first frame update
    void Start()
    {
        ThisIcon = GetComponent<Image>();
     
    }

    // Update is called once per frame
    void Update()
    {
        DeleteItem();
        ThisIcon.transform.position = Input.mousePosition;
    }
    public void TakeMoveable(IMove moveable)
    {
        this.ThisMove = moveable;
        ThisIcon.sprite = moveable.ThisIcon;
        ThisIcon.color = Color.white;
    }
    public IMove Put()
    {
        IMove imo = ThisMove;
        ThisMove = null;
        ThisIcon.color = new Color(0, 0, 0, 0);
        return imo;
    }
    public void Drop()
    {
        ThisMove = null;
        ThisIcon.color = new Color(0, 0, 0, 0);
    }
    private void DeleteItem()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && Instance.ThisMove != null)
        {
            if (ThisMove is Item && InventoryScript.Instance.FromSlot != null)
            {
                (ThisMove as Item).ThisSlot.Clear();
            }
            Drop();
            InventoryScript.Instance.FromSlot = null;
        }
    }
}
