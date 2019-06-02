using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestWindow : MonoBehaviour
{
    private static QuestWindow instance;
    public static QuestWindow Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<QuestWindow>();
            }
            return instance;
        }


    }
    [SerializeField]
    private GameObject backButton, acceptButton,questDescription;
    private QuestGiver questGiver;
    [SerializeField]
    private GameObject questPrefab;
    [SerializeField]
    private Transform questArea;
    public void ShowQuests(QuestGiver qGiver)
    {
        this.questGiver = qGiver;
        foreach (Quest quest in questGiver.Quests)
        {
            GameObject go = Instantiate(questPrefab, questArea);
            go.GetComponent<Text>().text = quest.ThisTitle;
            go.GetComponent<QGiverQScript>().ThisQuest = quest;
        }
    }
    public void ShowQuestInfo(Quest quest)
    {
        backButton.SetActive(true);
        acceptButton.SetActive(true);
        questArea.gameObject.SetActive(false);
        questDescription.gameObject.SetActive(true);

              string obj = "\nObjectives\n";
            foreach (Objective ob in quest.ThisCollectObjectives)
            {
                obj += ob.ThisType + " : " + ob.ThisCurrentAmount + "/" + ob.ThisAmount + "\n";
            }

            questDescription.GetComponent<Text>().text = string.Format("<b>{0}</b>\n<size=12>{1}</size>{2}", quest.ThisTitle, quest.ThisDescription, obj);
    }
}
