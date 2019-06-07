using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public delegate void GoldChange();
public class PlayerStats : MonoBehaviour
{

    public event GoldChange GoldChangeEvent;
    private static PlayerStats instance;
    //zwraca  instancje
    public static PlayerStats Instance
    {
        get
        {
            
            if(instance==null)
            {
                instance = FindObjectOfType<Player>().GetComponent<PlayerStats>();
                
            }
            return instance;
        }

       
    }
    //Zmienne
    [SerializeField]
    private int lifes=1;
    [SerializeField]
    private Text goldText;
    [SerializeField]
    private Text mHealthText;
    [SerializeField]
    private Text mMsText;
    [SerializeField]
    private Text mAsText;
    [SerializeField]
    private Text mDamageText;
    [SerializeField]
    private Text mLifesText;
    [SerializeField]
    public Text healthBarText;
    private Image healthBarImage;
    public GameObject HealthBar;
    private float currentHealthBarFill;
    private float movementSpeed;
    private int msLevel=0;
    private int asLevel=0;
    private int hpLevel=1;
    private int dmgLevel=0;
    private float maxHealth;
    private float currentHealth;
    private float atackSpeed;
    private int gold;
    private float damage;
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
            if (value > 5)

            {
                movementSpeed = 5;
            }
            else
            {

                if(msLevel<5)
                {
                    msLevel++;
                    movementSpeed = value;
                }
            }
            mMsText.text = "Movement Speed : " + movementSpeed + " Level " + msLevel + "/5";
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
            else if (value <=0)
            {
                currentHealth = 0f;
                Lifes--;
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
            mHealthText.text = "Health : " + CurrentHealth + "/" + maxHealth + " Level " + hpLevel + "/5";
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
            if(hpLevel <5)
            {
                hpLevel++;
                maxHealth = value;
            }
            mHealthText.text = "Health : " + CurrentHealth + "/" + maxHealth + "Level" + hpLevel + "/5";
            currentHealthBarFill = currentHealth / maxHealth;
            healthBarText.text = currentHealth + " / " + maxHealth;
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {
            if (value < 0)
            {
                gold = 0;
            }

            gold = value;
            OnGoldChange();
            goldText.text = gold + " G ";
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            if(dmgLevel<5)
            {
                dmgLevel++;
                damage = value;
            }
            mDamageText.text = "Damage :" + Damage + " Level " + dmgLevel + "/5";
        }
    }

    public float AtackSpeed
    {
        get
        {
            return atackSpeed;
        }

        set
        {
            
            
            atackSpeed = value;
            mAsText.text= "Atack Speed :" + Math.Round(atackSpeed, 2,MidpointRounding.ToEven) + " Level " + AsLevel + "/5";
        }
    }

    public int AsLevel
    {
        get
        {
            return asLevel;
        }

        set
        {
            asLevel = value;
        }
    }
    public int Lifes
    {
        get
        {
            return lifes;
        }

        set
        {
            if (value <= 0)
            {
                SceneManager.LoadScene("GameOver");
                return;
            }

            if (lifes > value)
            {
                GameManager.Instance.DayCount++;
                CurrentHealth = MaxHealth;
                CameraFollow.Instance.SetLimits(new Vector3(-12.8f, -7.2f), new Vector3(12.8f, 7.2f));
                Player.Instance.transform.position = new Vector3(0, 0, 0);
               
            }
            lifes = value;
        

            mLifesText.text = "Lifes : " + lifes;
        }
    }
    public void OnGoldChange()
    {
        if (GoldChangeEvent != null)
        {
            GoldChangeEvent();
        }
    }
}
