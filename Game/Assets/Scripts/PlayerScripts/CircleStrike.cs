using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStrike : AbilityScript
{
    private Player player;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    float rotationR = 2f;
    [SerializeField]
    private float angle = 0f;
    float posX, posY;
    bool close = false;

    public float Angle
    {
        get
        {
            return angle;
        }

        set
        {
            angle = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
      
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotate();
    }
    private void Rotate()
    {
       if(close!=false)
        {
            rotationR += Time.fixedDeltaTime;
            if(rotationR>5f)
            {
                close = false;
            }
        }
        else
        {
            rotationR -= Time.fixedDeltaTime;
            if(rotationR<2f)
            {
                close = true;
            }
        }
        posX = player.transform.position.x + Mathf.Cos(Angle) * rotationR;
        posY = player.transform.position.y + Mathf.Sin(Angle) * rotationR;
        transform.position = new Vector2(posX, posY);
        Angle = Angle + Time.fixedDeltaTime * speed;
        if(Angle >= 360f)
        {
            Angle = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Enemy")
        {
         
            collision.gameObject.GetComponent<StatHealth>().CurrentValue -= Damage;
        }
        if (collision.gameObject.tag == "Boss" && !collision.gameObject.GetComponent<EnemyScript>().IsImmortal)
        {
            collision.gameObject.GetComponent<StatHealth>().CurrentValue -= Damage;
        }
    }
}
