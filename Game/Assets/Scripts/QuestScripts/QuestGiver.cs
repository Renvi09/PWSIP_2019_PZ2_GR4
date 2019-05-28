using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{

    [SerializeField]
    private Quest[] quests;
    //debug
    [SerializeField]
    private QuestLog tmpLog;
    private void Awake()
    {
        tmpLog.AcceptQuest(quests[0]);
        tmpLog.AcceptQuest(quests[1]);
    }
}
