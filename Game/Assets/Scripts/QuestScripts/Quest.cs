using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    [SerializeField]
    private string title;
    [SerializeField]
    private string description;
    public QuestScript ThisQuestScript { get; set; }
    [SerializeField]
    private CollectObjective[] collectObjectives;
    [SerializeField]
    private Kill[] killObjectives;
    [SerializeField]
    private Gold[] goldObjectives;
    public string ThisTitle
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public string ThisDescription
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }

    public CollectObjective[] ThisCollectObjectives
    {
        get
        {
            return collectObjectives;
        }

    }
    public bool isComplete
    {
        get
        {
            foreach(Objective ob in collectObjectives)
            {
                if(!ob.isComplete)
                {
                    return false;
                }
                
            }
            foreach (Objective ob in KillObjectives)
            {
                if (!ob.isComplete)
                {
                    return false;
                }
            }
            foreach (Objective ob in GoldObjectives)
            {
                if (!ob.isComplete)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public Gold[] GoldObjectives
    {
        get
        {
            return goldObjectives;
        }

    }

    public Kill[] KillObjectives
    {
        get
        {
            return killObjectives;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public abstract class Objective
{
    public bool isComplete
    {
        get
        {
            return ThisCurrentAmount >= ThisAmount;
        }
    }
    [SerializeField]
    private int amount;
  
    private int currentAmount;
    [SerializeField]
    private string type;

    public int ThisAmount
    {
        get
        {
            return amount;
        }
    }

    public int ThisCurrentAmount
    {
        get
        {
            return currentAmount;
        }

        set
        {
            currentAmount = value;
        }
    }

    public string ThisType
    {
        get
        {
            return type;
        }
    }
}
[System.Serializable]
public class CollectObjective : Objective
{
    public void UpdateItemCount(Item item)
    {
        if (ThisType.ToLower() == item.ThisTitle.ToLower())
        {
            ThisCurrentAmount = InventoryScript.Instance.GetItemCount(ThisType);
            QuestLog.Instance.UpdateSelected();
            QuestLog.Instance.ChectCompletion();

        }
    }
    public void UpdateItemCount()
    {      
            ThisCurrentAmount = InventoryScript.Instance.GetItemCount(ThisType);
            QuestLog.Instance.UpdateSelected();
            QuestLog.Instance.ChectCompletion();       
    }
}
[System.Serializable]
public class Kill : Objective
{
    public void UpdateKillCount(EnemyScript enemy)
    {
        if(ThisType==enemy.ThisType)
        {
            ThisCurrentAmount++;
            QuestLog.Instance.UpdateSelected();
            QuestLog.Instance.ChectCompletion();
        }
    }
}
[System.Serializable]
public class Gold : Objective
{
    public void UpdateGoldCount()
    {
        ThisCurrentAmount = PlayerStats.Instance.Gold;
        QuestLog.Instance.UpdateSelected();
        QuestLog.Instance.ChectCompletion();

    }
}

