using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBlast : EnemyAtack
{
    float timer;
    bool spawned=false;

    private void Update()
    {
        timer += Time.deltaTime;
        if (wawe < howManny && !spawned && timer>1f)
        {
            spawned = true;
            var pos = Player.Instance.transform.position;
            var rotation = Quaternion.FromToRotation(Vector3.up, pos - transform.position);

            var bullet = (GameObject)Instantiate(
              this.gameObject,
              transform.position,
                rotation);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 5;
            bullet.GetComponent<EnemyAtack>().damage = 5+damage;
            bullet.GetComponent<EnemyAtack>().wawe = wawe + 1;

            Destroy(bullet, 2.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().CurrentHealth -= damage;
        }
        if (collision.gameObject.tag == "PlayerAtack")
        {
            Destroy(collision.gameObject);
        }
    }
}
