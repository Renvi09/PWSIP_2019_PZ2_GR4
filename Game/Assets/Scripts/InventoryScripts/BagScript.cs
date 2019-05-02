using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;
    private CanvasGroup canvasGroup;

  

    public bool IsOpen
    {
        get
        {
            return canvasGroup.alpha>0;
        }

      
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void AddSlots(int slotNumber)
    {
        for(int i =0;i<slotNumber;i++)
        {
            Instantiate(slotPrefab, transform);
        }
    }
    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }
}
