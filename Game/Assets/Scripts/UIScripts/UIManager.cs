using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update\
    [SerializeField]
    private Button[] actionButtons;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnClickButton(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            InventoryScript.Instance.OpenCloseInventory();
        }
    }
    private void OnClickButton(int buttonIndex)
    {
        actionButtons[buttonIndex].onClick.Invoke();
    }
}
