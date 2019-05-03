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
    private Button[] abbilityButtons;
   

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnClickButton(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnClickButton(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnClickButton(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnClickButton(4);
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
            clicable.ThisStackText.color =new Color(0, 0, 0, 0);
        }
        //jesli 0 ukrywa ikone
        if(clicable.ThisCount==0)
        {
            clicable.ThisIcon.color = new Color(0, 0, 0, 0);
            clicable.ThisStackText.color = new Color(0, 0, 0, 0);
        }
    }
    //uzywa umiejetosci 1-4
    private void OnClickButton(int buttonIndex)
    {
        abbilityButtons[buttonIndex].onClick.Invoke();
    }
}
