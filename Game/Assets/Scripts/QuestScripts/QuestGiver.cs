using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour,IInteractable
{
    [SerializeField]
    public CanvasGroup canvas;
    [SerializeField]
    private List<Quest> quests;

    public List<Quest> Quests
    {
        get
        {
            return quests;
        }

        set
        {
            quests = value;
        }
    }

    public void Interact()
    {
        if(canvas.alpha==0)
        {
            QuestWindow.Instance.ShowQuests(this);
            UIManager.Instance.OpenClose(canvas);
        }
        
    }

    public void StopInteract()
    {
        if (canvas.alpha == 1)
            UIManager.Instance.OpenClose(canvas);
    }

   
}
