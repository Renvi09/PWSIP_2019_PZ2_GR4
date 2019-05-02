using Assets.Scripts.UIScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour, IPointerClickHandler
{
    private IUse useable;
    public Button button { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        if(useable!=null)
        {
            useable.Use();
        }
    }
        
    public void OnPointerClick(PointerEventData eventData)
    {
       
    }
}
