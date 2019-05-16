using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    
    private static UIManager instance;
    //zwraca  instancje
    public static UIManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }


    }
    [SerializeField]
    private GameObject tooltip;
    [SerializeField]
    private ActionButton[] abbilityButtons;
    private Text tooltipText;
    private void Awake()
    {
        tooltipText = tooltip.GetComponentInChildren<Text>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnClickButton("AbilityButton1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnClickButton("AbilityButton2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnClickButton("AbilityButton3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnClickButton("AbilityButton4");
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            InventoryScript.Instance.OpenCloseInventory();
        }
    }
    public void UpdateStackSize(IClicable clicable)
    {
        //jesli stack jest wiekszy niz 1 to pokazyje i ustawia ulosc stakow
        if(clicable.ThisCount>1)
        {
            clicable.ThisStackText.text = clicable.ThisCount.ToString();
            clicable.ThisStackText.color = Color.white;
            clicable.ThisIcon.color = Color.white;
        }
        //jesli stack jest tniejszy niz 2 ukrywa stack size
        else
        {
            clicable.ThisStackText.color = new Color(0, 0, 0, 0);
            clicable.ThisIcon.color = Color.white;
        }
        //jesli 0 ukrywa ikone
        if(clicable.ThisCount==0)
        {
            clicable.ThisIcon.color = new Color(0, 0, 0, 0);
            clicable.ThisStackText.color = new Color(0, 0, 0, 0);
        }
    }
    //uzywa umiejetosci 1-4
    private void OnClickButton(string buttonName)
    {
        Array.Find(abbilityButtons, x => x.gameObject.name == buttonName).ThisButton.onClick.Invoke();
    }
 
    public void OpenClose(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }
    public void ShowTooltip(Vector3 position,IDescribable description)
    {
        tooltip.SetActive(true);
        tooltip.transform.position = position;
        tooltipText.text = description.GetDescription();

        
    }
    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

}
