using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private GameObject backButton, acceptButton,questDescription,completeButton;
    private QuestGiver questGiver;
    [SerializeField]
    private GameObject questPrefab;
    [SerializeField]
    private Transform questArea;
    private List<GameObject> quests = new List<GameObject>();
    private Quest selectedQuest;
    public void ShowQuests(QuestGiver qGiver)
    {
        this.questGiver = qGiver;
        foreach(GameObject go in quests)
        {
            Destroy(go);
        }
        foreach (Quest quest in questGiver.Quests)
        {
            if (quest != null)
            {
                GameObject go = Instantiate(questPrefab, questArea);
                go.GetComponent<Text>().text = quest.ThisTitle;
                go.GetComponent<QGiverQScript>().ThisQuest = quest;
                quests.Add(go);
                if (QuestLog.Instance.HasQuest(quest) && quest.isComplete)
                {
                    go.GetComponent<Text>().text += "(c)";

                }
                else if (QuestLog.Instance.HasQuest(quest))
                {
                    Color c = go.GetComponent<Text>().color;
                    c.a = 0.5f;
                    go.GetComponent<Text>().color = c;
                }
            }
        }
    }
    public void ShowQuestInfo(Quest quest)
    {
        selectedQuest = quest;
        if (QuestLog.Instance.HasQuest(quest) && quest.isComplete )
        {
            acceptButton.SetActive(false);
            completeButton.SetActive(true);
        }
        else if (!QuestLog.Instance.HasQuest(quest))
        {
            acceptButton.SetActive(true);

        }
        string obj = "\nObjectives\n";
        string rew = "\nReward\n";
        backButton.SetActive(true);
        questArea.gameObject.SetActive(false);
        questDescription.gameObject.SetActive(true);

        if (selectedQuest.ThisTitle == "Pay Debts")
        {

           questDescription.GetComponent<Text>().text= string.Format("<b>{0}</b>\n<size=12>{1}</size>{2}Win Game.", quest.ThisTitle, quest.ThisDescription,  rew);
        }
        else
        {
             questDescription.GetComponent<Text>().text = string.Format("<b>{0}</b>\n<size=12>{1}</size>{2}{3}G", quest.ThisTitle, quest.ThisDescription, rew, quest.ThisReward);
        }
        
    }
    public void Back()
    {
        backButton.SetActive(false);
        acceptButton.SetActive(false);
        completeButton.SetActive(false);
        questArea.gameObject.SetActive(true);
        questDescription.gameObject.SetActive(false);
        ShowQuests(questGiver);
      

    }
    public void Accept()
    {
        QuestLog.Instance.AcceptQuest(selectedQuest);
        Back();
    }
    public void CompleteQuest()
    {
        if(selectedQuest.isComplete)
        {
            for (int i = 0; i < questGiver.Quests.Count; i++)
            {
                if(selectedQuest==questGiver.Quests[i])
                {
                    if (selectedQuest.ThisTitle == "Pay Debts")
                    {
                        SceneManager.LoadScene("Credits");
                            return;
                    }
                    PlayerStats.Instance.Gold += selectedQuest.ThisReward;
                    questGiver.Quests.Remove(selectedQuest);
                    
                }
            }
            foreach(CollectObjective ob in selectedQuest.ThisCollectObjectives)
            {
                InventoryScript.Instance.itemCountChangedEvent -= new ItemCountChanged(ob.UpdateItemCount);
                ob.Complete();
            }
            foreach (Kill ob in selectedQuest.KillObjectives)
            {
                GameManager.Instance.KillConfirmedEvent -= new KillConfirmed(ob.UpdateKillCount);

            }
            foreach (Gold ob in selectedQuest.GoldObjectives)
            {
                PlayerStats.Instance.GoldChangeEvent -= new GoldChange(ob.UpdateGoldCount);
                PlayerStats.Instance.Gold -= ob.ThisAmount;
            }
            Back();
        }

    }
}
