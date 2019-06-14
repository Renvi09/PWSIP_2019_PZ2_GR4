using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHealth : MonoBehaviour
{ 
    private float currentFill;
    public float maxValue { get; set; }
    public GameObject HealthBar;
    private Image healthBarImage;
    [SerializeField]
    private float currentValue;
    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
           

            if (value > maxValue)
            {
                currentValue = maxValue;
            }
            else if (value <1)
            {
                currentValue = 0;
                PlayerStats.Instance.Gold += Random.Range(0,GetComponent<EnemyScript>().gold);
                GameManager.Instance.enemyList.Remove(this.gameObject);
                GameManager.Instance.OnKillConfirmed(GetComponent<EnemyScript>());
                Destroy(this.gameObject);
                

            }
            else
            {
                currentValue = value;
            }
            if (currentValue == 0)

            {
                currentFill = 0;
            }
            else
            {

                currentFill = currentValue / maxValue;
            }
          
               
            
           
       

        }

    }


    // Start is called before the first frame update
    void Start()
    {
     
        healthBarImage = HealthBar.GetComponent<Image>();
        maxValue = currentValue;
        CurrentValue = currentValue;

    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarImage.fillAmount != currentFill)
        {
            healthBarImage.fillAmount = currentFill;
        }
    }
}
