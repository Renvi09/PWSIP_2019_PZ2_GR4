using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{

    private static QuestLog instance;
    //zwraca  instancje
    public static QuestLog Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<QuestLog>();

            }
            return instance;
        }


    }

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

    private List<QuestScript> questScripts = new List<QuestScript>();
    private List<Quest> quests = new List<Quest>();
    private List<GameObject> questsObjects = new List<GameObject>();
    private CanvasGroup canvas;
    [SerializeField]
    private GameObject questPrefab;
    [SerializeField]
    private Transform questParent;
    [SerializeField]
    private Text questDescription;
    private Quest selectedQuest;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            
            OpenClose();
           

        }
    }
    public void OpenClose()
    {
        UIManager.Instance.OpenClose(canvas);
    }
    public void AcceptQuest(Quest quest)
    {
        foreach (CollectObjective ob in quest.ThisCollectObjectives)
        {
            InventoryScript.Instance.itemCountChangedEvent += new ItemCountChanged(ob.UpdateItemCount);
            ob.UpdateItemCount();
        }
        foreach (Kill ob in quest.KillObjectives)
        {
            GameManager.Instance.KillConfirmedEvent += new KillConfirmed(ob.UpdateKillCount);
            
        }
        foreach (Gold ob in quest.GoldObjectives)
        {
            PlayerStats.Instance.GoldChangeEvent += new GoldChange(ob.UpdateGoldCount);
            PlayerStats.Instance.Gold = PlayerStats.Instance.Gold;
        }
        Quests.Add(quest);
        GameObject go = Instantiate(questPrefab, questParent);
        questsObjects.Add(go);
        QuestScript qs = go.GetComponent<QuestScript>();
        qs.ThisQuest = quest;
        quest.ThisQuestScript = qs;
        questScripts.Add(qs);
        go.GetComponent<Text>().text = quest.ThisTitle;
        ChectCompletion();
    }
    public void ShowDescription(Quest quest)
    {
        if(quest!=null)
        {
            if (selectedQuest != null && selectedQuest!=quest)
            {
                selectedQuest.ThisQuestScript.DeSelect();
            }
            string obj = "\nObjectives\n";
            string rew = "\nReward\n";
            foreach (Objective ob in quest.ThisCollectObjectives)
            {
                obj += ob.ThisType + " : " + ob.ThisCurrentAmount + "/" + ob.ThisAmount + "\n";
            }
            foreach (Objective ob in quest.KillObjectives)
            {
                obj += ob.ThisType + " : " + ob.ThisCurrentAmount + "/" + ob.ThisAmount + "\n";
            }
            foreach (Objective ob in quest.GoldObjectives)
            {
                obj += ob.ThisType + " : " + ob.ThisCurrentAmount + "/" + ob.ThisAmount + "\n";
            }
            selectedQuest = quest;
            if (selectedQuest.ThisTitle == "Pay Debts")
            {

                questDescription.text = string.Format("<b>{0}</b>\n<size=12>{1}</size>{2}{3}Win Game.", quest.ThisTitle, quest.ThisDescription, obj, rew);
            }
            else
            {
                questDescription.text = string.Format("<b>{0}</b>\n<size=12>{1}</size>{2}{3}{4}G", quest.ThisTitle, quest.ThisDescription, obj, rew, quest.ThisReward);
            }
         
        }

    }
    public void UpdateSelected()
    {
        ShowDescription(selectedQuest);
    }
    public void ChectCompletion()
    {
        foreach (QuestScript qs in questScripts)
        {
            qs.IsComplete();
        }
    }
    public bool HasQuest(Quest quest)
    {
        
        return Quests.Exists(x=>x.ThisTitle ==quest.ThisTitle);
    }

}
