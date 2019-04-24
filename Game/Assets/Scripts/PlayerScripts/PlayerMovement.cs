using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int i;
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody2D;
    private Vector2 direction;
    // Start is called before the first frame update
    PlayerStats playerStats;
    private bool isMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;

        }
    }

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
        playerStats.MovementSpeed = 3;
        playerStats.CurrentHealth = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //debug
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(playerStats.CurrentHealth);
            playerStats.CurrentHealth += 5;
            i++;

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(playerStats.CurrentHealth);
            playerStats.CurrentHealth -= 5 ;
            i++;

        }
        AnimationLayerControl();
    }

    private void FixedUpdate()
    {

        PlayerMove();
    }

    private void PlayerAtack()
    {

    }

    private void AnimationLayerControl()
    {
        if (isMoving)
        {

            AnimationMovement(direction);


        }
        else
        {
            AnimationLayerSet("Idle");
            playerRigidbody2D.velocity = new Vector2(0,0);
        }
    }
    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical") ;
        direction = new Vector2(horizontal, vertical);
        playerRigidbody2D.velocity = direction.normalized *playerStats.MovementSpeed;

        
    }
   
    private void AnimationMovement(Vector2 direction)
    {

        AnimationLayerSet("Walk");
        playerAnimator.SetFloat("x", direction.x);
        playerAnimator.SetFloat("y", direction.y);
    }
    private void AnimationAtack(int fireWay)
    {
        AnimationLayerSet("Atack");
        playerAnimator.SetFloat("Fire", fireWay);
       
    }
    private void AnimationLayerSet(string layerName)
    {
       for(int i =0;i<playerAnimator.layerCount;i++)
        {
            playerAnimator.SetLayerWeight(i, 0);
        }
        playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex(layerName), 1);
     
          
    }

}
