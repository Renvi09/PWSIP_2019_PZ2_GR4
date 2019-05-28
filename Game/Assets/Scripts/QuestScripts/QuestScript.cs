using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{
    public Quest ThisQuest { get; set; }
    private bool markedComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select()
    {
        GetComponent<Text>().color = Color.yellow;
        QuestLog.Instance.ShowDescription(ThisQuest);
    }

    public void DeSelect()
    {
        GetComponent<Text>().color = Color.white;
    }
    public void IsComplete()
    {
        if(ThisQuest.isComplete && !markedComplete)
        {
            markedComplete = true;
            GetComponent<Text>().text += "(COMPLETE)";
        }
        else if(!ThisQuest.isComplete)
        {
            markedComplete = false;
            GetComponent<Text>().text = ThisQuest.ThisTitle;
        }
       
    }
}
