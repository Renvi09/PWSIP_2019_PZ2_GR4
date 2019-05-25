using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    public void Close()
    {

        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
       
    }

    public void Open()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

}
