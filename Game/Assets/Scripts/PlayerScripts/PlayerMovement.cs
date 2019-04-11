using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerStats playerStats;
    void Start()
    {

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {

         
            float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * playerStats.movementSpeed;
            float vertical = Input.GetAxis("Vertical") * Time.deltaTime * playerStats.movementSpeed;
            transform.Translate(horizontal, vertical, 0);
        }
    }


}
