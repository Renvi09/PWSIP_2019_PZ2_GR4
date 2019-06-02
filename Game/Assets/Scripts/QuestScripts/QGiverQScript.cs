using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QGiverQScript : MonoBehaviour
{
    public Quest ThisQuest { get; set; }
    public void Select()
    {
        QuestWindow.Instance.ShowQuestInfo(ThisQuest);
    }
}
