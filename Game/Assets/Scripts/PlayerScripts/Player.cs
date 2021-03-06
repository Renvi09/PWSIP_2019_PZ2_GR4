﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    //fordebug
    public GameObject enemy;
   //
    private static Player instance;
    //zwraca  instancje
    public static Player Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
                
            }
            return instance;
        }


    }
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody2D;
    private Vector2 direction;
    // Start is called before the first frame update
    private PlayerStats playerStats;
    private float timer;
    public IInteractable interactable;

    private float timeBetweenBullets = 1f;

    private bool isMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;

        }
    }

    public float TimeBetweenBullets
    {
        get
        {
            return timeBetweenBullets;
        }

        set
        {
            if (playerStats.AsLevel<5)
            {
                playerStats.AsLevel++;
                timeBetweenBullets = value;
                playerStats.AtackSpeed = 1/ TimeBetweenBullets;
            }

            
        }
    }

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
        playerStats.MovementSpeed = 3;
        playerStats.CurrentHealth =100;
        playerStats.Gold = 9990;
        TimeBetweenBullets = 1f;
        playerStats.Damage = 10f;
        playerStats.Lifes = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        AnimationLayerControl();
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            playerStats.Gold = 0;
        }
    }

    private void FixedUpdate()
    {
        PlayerAtack();
        PlayerMove();
    }
    private void PlayerAtack()
    {
        if ((Input.GetMouseButton(0) && timer > TimeBetweenBullets && !EventSystem.current.IsPointerOverGameObject()) || (Input.GetMouseButtonDown(0) && timer>TimeBetweenBullets && !EventSystem.current.IsPointerOverGameObject()))
        {
            timer = 0f;
            var pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            var rotation = Quaternion.FromToRotation(Vector3.up, pos - transform.position);

            var bullet = (GameObject)Instantiate(
                playerStats.SpellList[0],
              transform.position,
                rotation);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 8;
            Destroy(bullet, 2.0f);
        }
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
    public void Interact()
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LootBox" || collision.tag == "NPC")
        {
            interactable = collision.GetComponent<IInteractable>();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LootBox" || collision.tag == "NPC")
        {
            if (interactable != null)
            {
                UIManager.Instance.HideTooltip();
                interactable.StopInteract();
                interactable = null;
            }
           
        }
    }
}
