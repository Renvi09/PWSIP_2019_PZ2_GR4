using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHealth : MonoBehaviour
{
    private Image healthBarImage;
    public GameObject HealthBar;
    private float currentFill;
    public float maxValue { get; set; }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if(value>maxValue)
            {
                currentValue = maxValue;
            }
            else if(value<0)
            {
                currentValue = 0f;
            }
            else
            {
                currentValue = value;
            }
            currentFill = maxValue / currentValue; 
        }

    }

    private float currentValue;
    // Start is called before the first frame update
    void Start()
    {
        healthBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount = currentFill;
    }
}
