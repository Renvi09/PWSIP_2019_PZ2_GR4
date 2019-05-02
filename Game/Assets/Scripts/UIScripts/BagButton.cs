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

    public Bag Bag
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
       if(bag!=null)
        {
            bag.bagScript.OpenClose();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
