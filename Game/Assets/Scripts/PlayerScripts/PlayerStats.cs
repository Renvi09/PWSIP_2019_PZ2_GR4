using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{


    private static PlayerStats instance;
    //zwraca  instancje
    public static PlayerStats Instance
    {
        get
        {
            
            if(instance==null)
            {
                instance = FindObjectOfType<Player>().GetComponent<PlayerStats>();
                ;
            }
            return instance;
        }

       
    }
    //Zmienne
    [SerializeField]
    private Text goldText;
    public Text healthBarText;
    private Image healthBarImage;
    public GameObject HealthBar;
    private float currentHealthBarFill;
    private float movementSpeed;
    private float maxHealth;
    private float currentHealth;
    private float gold;
    public List<GameObject> SpellList;
    void Start()
    {
        maxHealth = 100;
        healthBarImage = HealthBar.GetComponent<Image>();

    }
    void Update()
    {
        if (healthBarImage.fillAmount != currentHealthBarFill)
        {
            healthBarImage.fillAmount = currentHealthBarFill;
        }
    
    }
    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }

        set
        {
           
            movementSpeed = value;
        }
    }

  

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else if (value < 0)
            {
                currentHealth = 0f;
            }
            else
            {
                currentHealth= value;
            }

            //Ustawienie HealthBarFill
            if (currentHealth == 0)

            {
                currentHealthBarFill = 0;
            }
            else
            {
                currentHealthBarFill = currentHealth / maxHealth;
            }
            healthBarText.text = currentHealth + " / " + maxHealth;
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = value;
        }
    }

    public float Gold
    {
        get
        {
            return gold;
        }

        set
        {
            if (value < 0)
            {
                gold = 0f;
            }

            gold = value;
            goldText.text = gold + " G ";
        }
    }
}
