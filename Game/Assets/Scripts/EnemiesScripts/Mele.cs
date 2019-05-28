using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mele : EnemyScript
{
    private float timer = 0;
    private float timer2 = 0;
    [SerializeField]
    private float speed;
    void Start()
    {
        target = Player.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
       
        timer += Time.deltaTime;
        if (Vector2.Distance(transform.position, target.position)>1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (timer > 15f)
            {
                timer2 += Time.deltaTime;
                if(timer2>5f)
                {
                    timer = 0f;
                }
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed* 4 * Time.deltaTime);

            }
        }
        else
        {
            transform.position = this.transform.position;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.GetComponent<PlayerStats>().CurrentHealth -= dmg;
            Destroy(this.gameObject);
        }
    }
}


