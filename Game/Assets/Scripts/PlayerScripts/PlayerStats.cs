using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    //Zmienne
    public float movementSpeed { get; set; } = 1;
    public float healthPool { get; set; } = 1;
    public float currentHealth { get; set; } = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ToBeWounded(float ammountOfDamage)
    {
        currentHealth -= ammountOfDamage;

    }
    public void SetHealthPool(float newHealPool)
    {
        healthPool = newHealPool;
       
    }


}
