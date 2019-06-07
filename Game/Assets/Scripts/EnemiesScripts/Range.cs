using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : EnemyScript
{
    private float timer = 0;
    private float timeBetweenBullets = 0.5f;
    [SerializeField]
    private GameObject buttel;
    // Start is called before the first frame update
    void Start()
    {
        target = Player.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) < 5)
        {
            if (timer > timeBetweenBullets)
            {

                timer = 0f;
                var pos = target.position;
                var rotation = Quaternion.FromToRotation(Vector3.up, pos - transform.position);

                var bullet = (GameObject)Instantiate(
                    PlayerStats.Instance.SpellList[1],
                  transform.position,
                    rotation);
                bullet.transform.position = this.transform.position;
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 5;
                Destroy(bullet, 2.0f);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="player")
        {
            
            PlayerStats.Instance.CurrentHealth -= dmg * 2;
        }
    }
}
