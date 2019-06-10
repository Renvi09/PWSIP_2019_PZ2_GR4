using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayUpdateScript : MonoBehaviour
{
    private static DayUpdateScript instance;
    [SerializeField]
    private GameObject dayObject;
    public static DayUpdateScript Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<DayUpdateScript>();

            }
            return instance;
        }


    }

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Text dayText;
   

    public void UpdateDay(int day)
    {
        dayObject.SetActive(true);
        anim.Play("fade_in");
        dayText.text = "Day "+ day;
    }
    public void Deactive()
    {
        dayObject.SetActive(false);
    }
}
