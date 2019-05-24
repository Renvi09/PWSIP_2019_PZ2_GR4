using System.Collections;
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
    PlayerStats playerStats;
    float timer;
  
   
    public float timeBetweenBullets = 1f;
    
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
        playerStats.MovementSpeed = 8;
        playerStats.CurrentHealth = 50;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(playerStats.CurrentHealth);
            playerStats.CurrentHealth += 5;
            

        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(playerStats.CurrentHealth);
            playerStats.CurrentHealth -= 5 ;
          

        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            var ennn = (GameObject)Instantiate(
               enemy,
              transform.position- new Vector3(10,10,0),
                transform.rotation);
            ennn.GetComponent<EnemyAtack>().damage = 5;
            ennn.GetComponent<StatHealth>().maxValue = 150;

            ennn.GetComponent<StatHealth>().CurrentValue = 150;
            ennn.GetComponent<EnemyScript>().target = this.gameObject.transform;

        }
        AnimationLayerControl();
    }

    private void FixedUpdate()
    {
        PlayerAtack();
        PlayerMove();
    }
    public void xd()
    {
        Debug.Log("xd");
    }
    private void PlayerAtack()
    {
        if ((Input.GetMouseButton(0) && timer > timeBetweenBullets && !EventSystem.current.IsPointerOverGameObject()) || (Input.GetMouseButtonDown(0) && timer>timeBetweenBullets && !EventSystem.current.IsPointerOverGameObject()))
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
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 5;
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

}
